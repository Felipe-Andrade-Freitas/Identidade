using System;
using FACode.Identidade.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FACode.Identidade.API.Extensions
{
    public class CustomizeIdentityData
    {

        public string SCHEMA_IDENTITY => "Identity";

        public void OnModelCreatingMappings(ModelBuilder builder)
        {
            builder.Entity<User>(b =>
            {
                b.HasKey(u => u.Id);

                b.HasIndex(u => u.NormalizedUserName).HasName("UserNameIndex").IsUnique();
                b.HasIndex(u => u.NormalizedEmail).HasName("EmailIndex");

                b.ToTable("Users", SCHEMA_IDENTITY);


                b.Property(u => u.ConcurrencyStamp).IsConcurrencyToken();

                b.Property(u => u.Nome).HasMaxLength(700);
                b.Property(u => u.Responsabilidade).HasMaxLength(256);
                b.Property(u => u.Avatar);
                b.Property(u => u.UserName).HasMaxLength(256);
                b.Property(u => u.NormalizedUserName).HasMaxLength(256);
                b.Property(u => u.Email).HasMaxLength(256);
                b.Property(u => u.NormalizedEmail).HasMaxLength(256);

                b.HasMany<IdentityUserClaim<Guid>>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();

                b.HasMany<IdentityUserLogin<Guid>>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();

                b.HasMany<IdentityUserToken<Guid>>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();

                b.HasMany<IdentityUserRole<Guid>>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();
            });

            builder.Entity<IdentityUserClaim<Guid>>(b =>
            {
                b.HasKey(uc => uc.Id);

                b.ToTable("UserClaims", SCHEMA_IDENTITY);
            });

            builder.Entity<IdentityUserLogin<Guid>>(b =>
            {
                b.HasKey(l => new { l.LoginProvider, l.ProviderKey });

                b.Property(l => l.LoginProvider).HasMaxLength(128);
                b.Property(l => l.ProviderKey).HasMaxLength(128);

                b.ToTable("UserLogins", SCHEMA_IDENTITY);
            });

            builder.Entity<IdentityUserToken<Guid>>(b =>
            {
                b.HasKey(t => new { t.UserId, t.LoginProvider, t.Name });

                b.Property(t => t.LoginProvider);
                b.Property(t => t.Name);

                b.ToTable("UserTokens", SCHEMA_IDENTITY);
            });

            builder.Entity<IdentityRole<Guid>>(b =>
            {
                b.HasKey(r => r.Id);

                b.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

                b.ToTable("Roles", SCHEMA_IDENTITY);

                b.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

                b.Property(u => u.Name).HasMaxLength(256);
                b.Property(u => u.NormalizedName).HasMaxLength(256);

                b.HasMany<IdentityUserRole<Guid>>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();

                b.HasMany<IdentityRoleClaim<Guid>>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();
            });

            builder.Entity<IdentityRoleClaim<Guid>>(b =>
            {
                b.HasKey(rc => rc.Id);

                b.ToTable("RoleClaims", SCHEMA_IDENTITY);
            });

            builder.Entity<IdentityUserRole<Guid>>(b =>
            {
                b.HasKey(r => new { r.UserId, r.RoleId });

                b.ToTable("UserRoles", SCHEMA_IDENTITY);
            });
        }
    }
}