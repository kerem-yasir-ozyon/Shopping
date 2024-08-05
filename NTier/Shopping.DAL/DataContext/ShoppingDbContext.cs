﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shopping.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DAL.DataContext
{
    public class ShoppingDbContext : IdentityDbContext<AppUser,IdentityRole<int>,int>
    {
        public ShoppingDbContext(DbContextOptions<ShoppingDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Admin User Add

            string admin = "Admin";
            string mail = admin + "@mail.com";
            var hasher = new PasswordHasher<AppUser>();

            builder.Entity<AppUser>()
                   .HasData(new AppUser
                   {
                       Id = 1,
                       Name = "Admin",
                       Surname = "Admin",
                       UserName = "Admin",
                       NormalizedUserName = admin.ToUpper(),
                       Email = mail,
                       NormalizedEmail = mail.ToUpper(),
                       Birthdate = new DateOnly(1999,1,1),
                       gender = Common.Gender.none,
                       EmailConfirmed = true,
                       PhoneNumberConfirmed = true,
                       PhoneNumber = "-",
                       PasswordHash = hasher.HashPassword(null, "Az*123456789")
                   });

            //Admin Role Add

            builder.Entity<IdentityRole<int>>()
                   .HasData(new IdentityRole<int>
                   {
                       Id = 1,
                       Name = admin,
                       NormalizedName = admin.ToUpper()
                   });

            //User To Role Add

            builder.Entity<IdentityUserRole<int>>()
                   .HasData(new IdentityUserRole<int>
                   {
                       UserId = 1,
                       RoleId = 1
                   });
        }
    }
}
