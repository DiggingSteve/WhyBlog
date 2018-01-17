using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Threading;
using System.Threading.Tasks;
using WhyBlog.Models.Do;
using WhyBlog.Models.Do.Interface;

namespace WhyBlog.EF
{
    public class BlogContext : DbContext

    {
        private string conString = "";

        
        public BlogContext(DbContextOptions options) :base(options){
            
        }

        public BlogContext(string connection) => this.conString = connection;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrWhiteSpace(conString))
                optionsBuilder.UseMySql(conString);
            
        }

        public override int SaveChanges()
        {
            ApplyConcepts();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            ApplyConcepts();
            return await base.SaveChangesAsync(cancellationToken);
        }

        protected virtual void ApplyConcepts()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        break;
                    case EntityState.Modified:
                        break;
                    case EntityState.Deleted:
                        SetSoftDeleteProperties(entry);
                        break;
                }
            }
        }
        /// <summary>
        /// soft delete ,change flag 'IsDeleted ' to true
        /// </summary>
        /// <param name="entity"></param>
        protected void SetSoftDeleteProperties(EntityEntry entity)
        {
            if (entity.Entity is ISoftDeleted)
            {
                var entityObj = entity.Entity as ISoftDeleted;
                entityObj.IsDeleted = true;
                entity.State = EntityState.Modified;
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
           // builder.Entity<BaseEntity>().HasQueryFilter(p => p.IsDeleted == false);
        }

        

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }



    }
}
