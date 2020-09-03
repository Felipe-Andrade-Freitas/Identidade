
using System;
using FACode.Identidade.API.Extensions;
using FACode.Identidade.API.Migrations;
using FACode.Identidade.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FACode.Identidade.API.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public CustomizeIdentityData CustomizeIdentityData => new CustomizeIdentityData();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            CustomizeIdentityData.OnModelCreatingMappings(builder);
        }
    }
}