using NewsWebsite.Common;
using NewsWebsite.Data.Contracts;
using NewsWebsite.Entities;
using NewsWebsite.ViewModels.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace NewsWebsite.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly NewsDBContext _context;
        public CommentRepository(NewsDBContext context)
        {
            _context = context;
        }

        public int CountUnAnsweredComments() => _context.Comments.Where(c => c.IsConfirm == false).Count();
        public async Task<List<CommentViewModel>> GetPaginateCommentsAsync(int offset, int limit,string orderBy, string searchText,string newsId,bool? isConfirm)
        {

            var convertConfirm = Convert.ToBoolean(isConfirm);
            var getDateTimesForSearch = searchText.GetDateTimeForSearch();
            List<CommentViewModel> comments = await _context.Comments
                                   .Where(n=>(isConfirm==null || (convertConfirm==true?n.IsConfirm:!n.IsConfirm)) && n.NewsId.Contains(newsId) && ( n.Name.Contains(searchText) || n.Email.Contains(searchText) || (n.PostageDateTime >= getDateTimesForSearch.First() && n.PostageDateTime <= getDateTimesForSearch.Last())))
                                   .OrderBy(orderBy)
                                   .Skip(offset).Take(limit)
                                   .Select(l => new CommentViewModel {CommentId=l.CommentId,Name=l.Name , Email = l.Email, IsConfirm = l.IsConfirm, PersianPostageDateTime = l.PostageDateTime.ConvertMiladiToShamsi("yyyy/MM/dd ساعت HH:mm:ss") , Desription=l.Desription })
                                   .AsNoTracking()
                                   .ToListAsync();

            foreach (var item in comments)
                item.Row = ++offset;

            return comments;
        }
    }
}
