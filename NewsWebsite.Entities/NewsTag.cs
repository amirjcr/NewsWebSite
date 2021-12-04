using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Entities
{
    public class NewsTag
    {
        public string NewsId { get; set; }
        public string TagId { get; set; }

        public News News { get; set; }
        public Tag Tag { get; set; }

    }
}
