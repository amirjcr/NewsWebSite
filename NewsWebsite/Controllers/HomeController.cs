using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsWebsite.Common;
using NewsWebsite.Data.Contracts;
using NewsWebsite.Entities;
using NewsWebsite.ViewModels.Home;

namespace NewsWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _uw;
        private readonly IHttpContextAccessor _accessor;
        public HomeController(IUnitOfWork uw, IHttpContextAccessor accessor)
        {
            _uw = uw;
            _accessor = accessor;
        }

        public async Task<IActionResult> Index(string duration,string TypeOfNews)
        {
            var isAjax = Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            if (isAjax && TypeOfNews == "MostViewedNews")
                return PartialView("_MostViewedNews", await _uw.NewsRepository.MostViewedNewsAsync(0, 3, duration));


            else if (isAjax && TypeOfNews == "MostTalkNews")
                return PartialView("_MostTalkNews", await _uw.NewsRepository.MostTalkNews(0, 5, duration));

            else
            {
                int countNewsPublished = _uw.NewsRepository.CountNewsPublished();
                var news = await _uw.NewsRepository.GetPaginateNewsAsync(0, 10, "PublishDateTime desc","", true , null);
                var mostViewedNews = await _uw.NewsRepository.MostViewedNewsAsync(0, 3, "day");
                var mostTalkNews = await _uw.NewsRepository.MostTalkNews(0, 5, "day");
                var mostPopulerNews = await _uw.NewsRepository.MostPopularNews(0, 5);
                var internalNews =await _uw.NewsRepository.GetPaginateNewsAsync(0, 10, "PublishDateTime desc", "", true, true);
                var foreignNews = await _uw.NewsRepository.GetPaginateNewsAsync(0, 10, "PublishDateTime desc", "", true, false);
                var videos = await _uw.VideoRepository.GetPaginateVideosAsync(0, 10, "PublishDateTime desc", "");
                var homePageViewModel = new HomePageViewModel(news, mostViewedNews,mostTalkNews,mostPopulerNews,internalNews,foreignNews, videos, countNewsPublished);
                return View(homePageViewModel);
            }
           
        }

        [Route("News/{newsId}/{url}")]
        public async Task<IActionResult> NewsDetails(string newsId, string url)
        {
            if (!newsId.HasValue())
                return NotFound();
            else
            {
                int userId = User.Identity.GetUserId<int>();
                var existNews = await _uw.BaseRepository<News>().FindByIdAsync(newsId);
                if (existNews == null)
                    return NotFound();
                else
                {
                    string ipAddress = _accessor.HttpContext?.Connection?.RemoteIpAddress.ToString();
                    await _uw.NewsRepository.InsertVisitOfUserAsync(newsId, ipAddress);
                    var news = await _uw.NewsRepository.GetNewsByIdAsync(newsId, userId);
                    var newsComments = await _uw.NewsRepository.GetNewsCommentsAsync(newsId);
                    var nextAndPreviousNews = await _uw.NewsRepository.GetNextAndPreviousNews(news.PublishDateTime);
                    var newsRelated = await _uw.NewsRepository.GetRelatedNewsAsync(2, news.TagIdsList, newsId);
                    var newsDetailsViewModel = new NewsDetailsViewModel(news, newsComments, newsRelated, nextAndPreviousNews);
                    return View(newsDetailsViewModel);
                }
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetNewsPaginate(int limit, int offset)
        {
            int countNewsPublished = _uw.NewsRepository.CountNewsPublished();
            var news = await _uw.NewsRepository.GetPaginateNewsAsync(offset, limit, "PublishDateTime desc", "", true,null);
            return PartialView("_NewsPaginate", new NewsPaginateViewModel(countNewsPublished, news));
        }


        [Route("Category/{categoryId}/{url}")]
        public async Task<IActionResult> NewsInCategory(string categoryId, string url)
        {
            if (!categoryId.HasValue())
                return NotFound();
            else
            {
                var category = await _uw.BaseRepository<Category>().FindByIdAsync(categoryId);
                if (category == null)
                    return NotFound();
                else
                    return View("NewsInCategoryAndTag",new CategoryOrTagInfoViewModel {Id=category.CategoryId,Title=category.CategoryName,IsCategory=true});
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetNewsInCategoryAndTag(int pageIndex, int pageSize, string categoryId, string tagId)
        {
            if (categoryId.HasValue())
                return Json(await _uw.NewsRepository.GetNewsInCategoryAsync(categoryId, pageIndex, pageSize));

            else
                return Json(await _uw.NewsRepository.GetNewsInTagAsync(tagId, pageIndex, pageSize));
        }



        [Route("Tag/{tagId}")]
        public async Task<IActionResult> NewsInTag(string tagId)
        {
            if (!tagId.HasValue())
                return NotFound();
            else
            {
                var tag = await _uw.BaseRepository<Tag>().FindByIdAsync(tagId);
                if (tag == null)
                    return NotFound();
                else
                    return View("NewsInCategoryAndTag", new CategoryOrTagInfoViewModel { Id = tag.TagId, Title = tag.TagName, IsCategory = false });
            }
        }

        [Route("Videos")]
        public async Task<IActionResult> Videos()
        {
            return View(await _uw.BaseRepository<Video>().FindAllAsync());
        }

        [Route("Video/{videoId}")]
        public async Task<IActionResult> VideoDetails(string videoId)
        {
            if (!videoId.HasValue())
                return NotFound();
            else
            {
                var video = await _uw.BaseRepository<Video>().FindByIdAsync(videoId);
                if (video == null)
                    return NotFound();
                else
                    return View(video);
            }
        }

        [HttpGet]
        public async Task<JsonResult> LikeOrDisLike(string newsId, bool isLike)
        {
            string ipAddress = _accessor.HttpContext?.Connection?.RemoteIpAddress.ToString();
            Like likeOrDislike = _uw.BaseRepository<Like>().FindByConditionAsync(l => l.NewsId == newsId && l.IpAddress == ipAddress).Result.FirstOrDefault();
            if (likeOrDislike == null)
            {
                likeOrDislike = new Like { NewsId = newsId, IpAddress = ipAddress, IsLiked = isLike };
                await _uw.BaseRepository<Like>().CreateAsync(likeOrDislike);
            }
            else
                likeOrDislike.IsLiked = isLike;

            await _uw.Commit();
            var likeAndDislike = _uw.NewsRepository.NumberOfLikeAndDislike(newsId);
            return Json(new { like = likeAndDislike.NumberOfLike, dislike = likeAndDislike.NumberOfDisLike });
        }


        [HttpGet]
        public async Task<IActionResult> BookmarkNews(string newsId)
        {
            if (User.Identity.IsAuthenticated)
            {
                int userId = User.Identity.GetUserId<int>();
                Bookmark bookmark = _uw.BaseRepository<Bookmark>().FindByConditionAsync(l => l.NewsId == newsId && l.UserId == userId).Result.FirstOrDefault();
                if (bookmark == null)
                {
                    bookmark = new Bookmark { NewsId = newsId, UserId = userId };
                    await _uw.BaseRepository<Bookmark>().CreateAsync(bookmark);
                    await _uw.Commit();
                    return Json(true);
                }
                else
                {
                    _uw.BaseRepository<Bookmark>().Delete(bookmark);
                    await _uw.Commit();
                    return Json(false);
                }
            }

            else
                return PartialView("_SignIn");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Search(string searchText) => View(await _uw.NewsRepository.SearchInNews(searchText));

        [HttpGet]
        public IActionResult Error()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Error404()
        {
            return View();
        }

        public IActionResult Test()
        {
            return View();
        }
    }
}