using Microsoft.EntityFrameworkCore;
using NewsWebsite.Entities.identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsWebsite.Data.Mapping
{
    public static class IdentityMapping
    {
        public static void AddCustomIdentityMappings(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("AppUsers");
            modelBuilder.Entity<Role>().ToTable("AppRoles");
            modelBuilder.Entity<UserRole>().ToTable("AppUserRole");
            modelBuilder.Entity<RoleClaim>().ToTable("AppRoleClaim");
            modelBuilder.Entity<UserClaim>().ToTable("AppUserClaim");

            modelBuilder.Entity<UserRole>()
                .HasOne(userRole => userRole.Role)
                .WithMany(role => role.Users).HasForeignKey(r => r.RoleId);

            modelBuilder.Entity<UserRole>()
               .HasOne(userRole => userRole.User)
               .WithMany(role => role.Roles).HasForeignKey(r => r.UserId);

            modelBuilder.Entity<RoleClaim>()
                 .HasOne(roleclaim => roleclaim.Role)
                 .WithMany(claim => claim.Claims).HasForeignKey(c => c.RoleId);

            modelBuilder.Entity<UserClaim>()
                .HasOne(userClaim => userClaim.User)
                .WithMany(claim => claim.Claims).HasForeignKey(c => c.UserId);
        }
    }
}
