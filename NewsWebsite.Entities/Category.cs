using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NewsWebsite.Entities
{
    public class Category
    {
        [Key]
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }

        [ForeignKey("Parent")]
        public string ParentCategoryId { get; set; }
        public string Url { get; set; }

        public ICollection<NewsCategory> NewsCategories { get; set; }
        public virtual Category Parent { get; set; }
        public virtual List<Category> Categories { get; set; }

    }
}
