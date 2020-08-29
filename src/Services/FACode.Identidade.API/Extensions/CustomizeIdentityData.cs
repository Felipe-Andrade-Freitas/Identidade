using System;
using FACode.Identidade.API.Data;
using FACode.Identidade.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FACode.Identidade.API.Extensions
{
    public class CustomizeIdentityData
            : IdentityUserContext<User<Guid>, Guid, IdentityUserClaim<Guid>, IdentityUserLogin<Guid>, IdentityUserToken<Guid>>
    {

        public string SCHEMA_IDENTITY => "Identity";

        public void OnModelCreatingMappings(ModelBuilder builder)
        {
            builder.Entity<User<Guid>>(b =>
            {
                b.ToTable("Users", SCHEMA_IDENTITY);
                
                b.Property(u => u.Nome).HasMaxLength(700);
                b.Property(u => u.Responsabilidade).HasMaxLength(256);
                b.Property(u => u.Avatar);
            });

            builder.Entity<IdentityUserClaim<Guid>>(b => b.ToTable("UserClaims", SCHEMA_IDENTITY));
            builder.Entity<IdentityUserLogin<Guid>>(b => b.ToTable("UserLogins", SCHEMA_IDENTITY));
            builder.Entity<IdentityUserToken<Guid>>(b => b.ToTable("UserTokens", SCHEMA_IDENTITY));
            builder.Entity<IdentityUserRole<Guid>>(b => b.ToTable("Roles", SCHEMA_IDENTITY));
            builder.Entity<IdentityUserClaim<Guid>>(b => b.ToTable("RoleClaims", SCHEMA_IDENTITY));
            builder.Entity<IdentityUserRole<Guid>>(b => b.ToTable("UserRoles", SCHEMA_IDENTITY));
        }
    }
}