using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsWebsite.Data.Contracts;
using NewsWebsite.ViewModels.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebsite.ViewComponents
{
    public class LatestNewsTitleList : ViewComponent
    {
        private readonly IUnitOfWork _uw;
        public LatestNewsTitleList(IUnitOfWork uw)
        {
            _uw = uw;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var newsTitles = await _uw._Context.News.Where(n => n.IsPublish == true && n.PublishDateTime <= DateTime.Now).OrderByDescending(n => n.PublishDateTime).Select(n => new NewsViewModel {Title=n.Title,Url=n.Url,NewsId=n.NewsId}).Take(10).ToListAsync();
            return View(newsTitles);
        }
    }
}
