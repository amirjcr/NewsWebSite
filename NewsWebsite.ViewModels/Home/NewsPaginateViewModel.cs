using NewsWebsite.ViewModels.News;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.ViewModels.Home
{
    public class NewsPaginateViewModel
    {
        public NewsPaginateViewModel(int newsCount, List<NewsViewModel> news)
        {
            NewsCount = newsCount;
            News = news;
        }

        public int NewsCount { get; set; }
        public List<NewsViewModel> News { get; set; }
    }

}
