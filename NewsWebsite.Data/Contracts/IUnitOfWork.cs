using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsWebsite.Data.Contracts
{
    public interface IUnitOfWork
    {
        IBaseRepository<TEntity> BaseRepository<TEntity>() where TEntity : class;
        ICategoryRepository CategoryRepository { get; }
        ITagRepository TagRepository { get; }
        IVideoRepository VideoRepository { get; }
        INewsRepository NewsRepository { get; }
        INewsletterRepository NewsletterRepository { get; }
        ICommentRepository CommentRepository { get; }
        NewsDBContext _Context { get; }
        Task Commit();
    }
}
