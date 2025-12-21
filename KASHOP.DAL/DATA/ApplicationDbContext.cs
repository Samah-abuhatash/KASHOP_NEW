using KASHOP.DAL.Moadels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.DATA
{
    public  class ApplicationDbContext : IdentityDbContext<Applicationuser>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DbSet<Categores> Catgores { get; set; }
        public DbSet<CategoryTranslation> transelation { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
           : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Applicationuser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        }
        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries<Basemodels>();

            var currentUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    entityEntry.Property(x => x.CreatedBy).CurrentValue = currentUserId;
                    entityEntry.Property(x => x.CreatedAT).CurrentValue = DateTime.UtcNow;
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    entityEntry.Property(x => x.UpdatedBy).CurrentValue = currentUserId;
                    entityEntry.Property(x => x.UpdatedAt).CurrentValue = DateTime.UtcNow;
                }
            }

            return base.SaveChanges();
        }
    }
}

