using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewsWebsite.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Mapping
{
    public class VisitMapping : IEntityTypeConfiguration<Visit>
    {
        public void Configure(EntityTypeBuilder<Visit> builder)
        {
            builder.HasKey(t => new { t.NewsId, t.IpAddress });
            builder
              .HasOne(p => p.News)
              .WithMany(t => t.Visits)
              .HasForeignKey(f => f.NewsId);
        }
    }
}
