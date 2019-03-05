using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectManager.Core.Entities;
using ProjectManager.Persistence;
using ProjectManager.Web.Models;

namespace ProjectManager.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<TUser>(b =>
        //    {
        //        // Each User can have many UserClaims
        //        b.HasMany<TUserClaim>()
        //         .WithOne()
        //         .HasForeignKey(uc => uc.UserId)
        //         .IsRequired();
        //    });
        //}
    }
}
