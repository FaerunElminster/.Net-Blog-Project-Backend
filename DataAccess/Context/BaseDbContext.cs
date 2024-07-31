using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class BaseDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }

        public BaseDbContext()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = your_server_name; Trusted_Connection = True; TrustServerCertificate = True; Database = NttBlog");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
