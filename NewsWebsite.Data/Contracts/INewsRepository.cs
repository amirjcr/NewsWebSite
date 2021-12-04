using NewsWebsite.Entities;
using NewsWebsite.ViewModels.Home;
using NewsWebsite.ViewModels.News;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsWebsite.Data.Contracts
{
    public interface INewsRepository
    {
        string CheckNewsFileName(string fileName);
        int CountNewsPublished();
        Task<List<NewsViewModel>> GetPaginateNewsAsync(int offset, int limit, string orderBy, string searchText, bool? isPublish, bool? isInternal);
        Task<List<NewsViewModel>> MostViewedNewsAsync(int offset, int limit, string duration);
        Task<List<NewsViewModel>> MostTalkNews(int offset, int limit, string duration);
        Task<List<NewsViewModel>> MostPopularNews(int offset, int limit);
        Task<NewsViewModel> GetNewsByIdAsync(string newsId,int userId);
        Task<List<Comment>> GetNewsCommentsAsync(string newsId);
        Task BindSubComments(Comment comment);
        Task<List<NewsViewModel>> GetNextAndPreviousNews(DateTime? PublishDateTime);
        Task<List<NewsViewModel>> GetRelatedNewsAsync(int number, List<string> tagIdList, string newsId);
        Task<List<NewsInCategoriesAndTagsViewModel>> GetNewsInCategoryAsync(string categoryId, int pageIndex, int pageSize);
        Task<List<NewsInCategoriesAndTagsViewModel>> GetNewsInTagAsync(string TagId, int pageIndex, int pageSize);
        Task<List<NewsViewModel>> GetUserBookmarksAsync(int userId);
        NewsViewModel NumberOfLikeAndDislike(string newsId);
        Task<string> GetWeeklyNewsAsync();
        int CountNews();
        int CountFuturePublishedNews();
        int CountNewsPublishedOrDraft(bool isPublish);
        Task<List<NewsViewModel>> SearchInNews(string textSearch);

        Task InsertVisitOfUserAsync(string newsId, string ipAddress);
    }
}
