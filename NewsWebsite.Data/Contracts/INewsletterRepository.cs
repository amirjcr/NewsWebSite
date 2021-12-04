using NewsWebsite.Entities;
using NewsWebsite.ViewModels.Newsletter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsWebsite.Data.Contracts
{
    public interface INewsletterRepository
    {
        Task<List<NewsletterViewModel>> GetPaginateNewsletterAsync(int offset, int limit,string orderBy, string searchText);
    }
}
