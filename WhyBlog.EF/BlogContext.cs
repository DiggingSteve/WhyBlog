using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using WhyBlog.EF.Entity;

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


        protected override void OnModelCreating(ModelBuilder builder)
        {

            
            
          
            base.OnModelCreating(builder);
            
        }

        

        public virtual DbSet<User> Users { get; set; }



    }
}
