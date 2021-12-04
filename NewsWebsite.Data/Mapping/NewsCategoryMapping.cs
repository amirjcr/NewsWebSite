using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsWebsite.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Mapping
{
    public class NewsCategoryMapping : IEntityTypeConfiguration<NewsCategory>
    {
        public void Configure(EntityTypeBuilder<NewsCategory> builder)
        {
            builder.HasKey(t => new { t.CategoryId, t.NewsId });
            builder
              .HasOne(p => p.News)
              .WithMany(t => t.NewsCategories)
              .HasForeignKey(f => f.NewsId);

            builder
               .HasOne(p => p.Category)
               .WithMany(t => t.NewsCategories)
               .HasForeignKey(f => f.CategoryId);
        }
    }

}
