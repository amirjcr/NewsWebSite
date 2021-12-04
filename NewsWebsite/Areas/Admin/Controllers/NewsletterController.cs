using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NewsWebsite.Common;
using NewsWebsite.Data.Contracts;
using NewsWebsite.Entities;
using NewsWebsite.ViewModels.DynamicAccess;
using NewsWebsite.ViewModels.Newsletter;

namespace NewsWebsite.Areas.Admin.Controllers
{
    [DisplayName("مدیریت خبرنامه ")]
    public class NewsletterController : BaseController
    {
        private readonly IUnitOfWork _uw;
        private readonly IMapper _mapper;
        private const string EmailNotFound = "ایمیل یافت نشد...";
        public const string  RegisterSuccess = "عضویت شما در خبرنامه با موفقیت انجام شد.";
        public NewsletterController(IUnitOfWork uw, IMapper mapper)
        {
            _uw = uw;
            _uw.CheckArgumentIsNull(nameof(_uw));

            _mapper = mapper;
            _mapper.CheckArgumentIsNull(nameof(_mapper));
        }

        [HttpGet,DisplayName("مشاهده")]
        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetNewsletter(string search, string order, int offset, int limit, string sort)
        {
            List<NewsletterViewModel> newsletter;
            int total = _uw.BaseRepository<Newsletter>().CountEntities();
            if (!search.HasValue())
                search = "";

            if (limit == 0)
                limit = total;

            if (sort == "Id")
            {
                if (order == "asc")
                    newsletter = await _uw.NewsletterRepository.GetPaginateNewsletterAsync(offset, limit,"Email", search);
                else
                    newsletter = await _uw.NewsletterRepository.GetPaginateNewsletterAsync(offset, limit, "Email desc", search);
            }

            else if (sort == "تاریخ عضویت")
            {
                if (order == "asc")
                    newsletter = await _uw.NewsletterRepository.GetPaginateNewsletterAsync(offset, limit,"RegisterDateTime", search);
                else
                    newsletter = await _uw.NewsletterRepository.GetPaginateNewsletterAsync(offset, limit, "RegisterDateTime desc", search);
            }

            else
                newsletter = await _uw.NewsletterRepository.GetPaginateNewsletterAsync(offset, limit, "RegisterDateTime desc", search);

            if (search != "")
                total = newsletter.Count();

            return Json(new { total = total, rows = newsletter });
        }

        [HttpGet,DisplayName("حذف")]
        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        public async Task<IActionResult> Delete(string email)
        {
            if (!email.HasValue())
                ModelState.AddModelError(string.Empty, EmailNotFound);
            else
            {
                var newsletter = await _uw.BaseRepository<Newsletter>().FindByIdAsync(email);
                if (newsletter == null)
                    ModelState.AddModelError(string.Empty, EmailNotFound);
                else
                    return PartialView("_DeleteConfirmation", newsletter);
            }
            return PartialView("_DeleteConfirmation");
        }


        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Newsletter model)
        {
            if (!model.Email.HasValue())
                ModelState.AddModelError(string.Empty,EmailNotFound);
            else
            {
                var newsletter = await _uw.BaseRepository<Newsletter>().FindByIdAsync(model.Email);
                if (newsletter == null)
                    ModelState.AddModelError(string.Empty, EmailNotFound);
                else
                {
                    _uw.BaseRepository<Newsletter>().Delete(newsletter);
                    await _uw.Commit();
                    TempData["notification"] = DeleteSuccess;
                    return PartialView("_DeleteConfirmation", newsletter);
                }
            }
            return PartialView("_DeleteConfirmation");
        }


        [HttpPost, ActionName("DeleteGroup"),DisplayName("حذف گروهی")]
        [Authorize(Policy = ConstantPolicies.DynamicPermission)]
        public async Task<IActionResult> DeleteGroupConfirmed(string[] btSelectItem)
        {
            if (btSelectItem.Count() == 0)
                ModelState.AddModelError(string.Empty, "هیچ کاربری برای حذف انتخاب نشده است.");
            else
            {
                foreach (var item in btSelectItem)
                {
                    var newsletter = await _uw.BaseRepository<Newsletter>().FindByIdAsync(item);
                    _uw.BaseRepository<Newsletter>().Delete(newsletter);
                }

                await _uw.Commit();
                TempData["notification"] = "حذف گروهی اطلاعات با موفقیت انجام شد.";
            }

            return PartialView("_DeleteGroup");
        }

        public async Task<IActionResult> RegisterInNewsLetter(NewsletterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _uw.BaseRepository<Newsletter>().FindByIdAsync(viewModel.Email);
                if (user == null)
                {
                    await _uw.BaseRepository<Newsletter>().CreateAsync(new Newsletter(viewModel.Email));
                    await _uw.Commit();
                    TempData["notification"] = RegisterSuccess;
                }
                else
                {
                    if (user.IsActive == true)
                        ModelState.AddModelError(string.Empty, $"شما با ایمیل '{viewModel.Email}' قبلا عضو خبرنامه شده اید.");
                    else
                    {
                        user.IsActive = true;
                        await _uw.Commit();
                        TempData["notification"] = RegisterSuccess;
                    }
                }
            }

            return PartialView("_RegisterInNewsLetter");
        }

        [HttpGet]
        public async Task<IActionResult> ActiveOrInActiveMembers(string email)
        {
            if(email.HasValue())
            {
                var newsletter = await _uw.BaseRepository<Newsletter>().FindByIdAsync(email);
                if(newsletter!=null)
                {
                    if (newsletter.IsActive)
                        newsletter.IsActive = false;
                    else
                        newsletter.IsActive = true;

                    _uw.BaseRepository<Newsletter>().Update(newsletter);
                    await _uw.Commit();
                    return Json("Success");
                }
            }
            return Json($"عضوی با ایمیل '{email}' یافت نشد !!!");
        }
    }
}