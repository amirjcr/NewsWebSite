﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewsWebsite.Data.Mapping;
using NewsWebsite.Entities;
using NewsWebsite.Entities.identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data
{
    public class NewsDBContext : IdentityDbContext<User,Role,int,UserClaim,UserRole,IdentityUserLogin<int>,RoleClaim,IdentityUserToken<int>>
    {
        public NewsDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.AddCustomIdentityMappings();
            builder.AddCustomNewsWebsiteMappings();
            builder.Entity<Video>().Property(b => b.PublishDateTime).HasDefaultValueSql("CONVERT(DATETIME, CONVERT(VARCHAR(20),GetDate(), 120))");
            builder.Entity<User>().Property(b => b.RegisterDateTime).HasDefaultValueSql("CONVERT(DATETIME, CONVERT(VARCHAR(20),GetDate(), 120))");
            builder.Entity<Newsletter>().Property(b => b.RegisterDateTime).HasDefaultValueSql("CONVERT(DATETIME, CONVERT(VARCHAR(20),GetDate(), 120))");
            builder.Entity<User>().Property(b => b.IsActive).HasDefaultValueSql("1");
            builder.Entity<Newsletter>().Property(b => b.IsActive).HasDefaultValueSql("1");
        }

        public virtual DbSet<Category> Categories { set; get; }
        public virtual DbSet<News> News { set; get; }
        public virtual DbSet<Bookmark> Bookmarks { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Like> Likes { get; set; }
        public virtual DbSet<NewsCategory> NewsCategories { get; set; }
        public virtual DbSet<Newsletter> Newsletters { get; set; }
        public virtual DbSet<NewsTag> NewsTags { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Visit> Visits { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
    }
}
