using Microsoft.EntityFrameworkCore;
using MiniBlogProject.Models;
using System.Security.Cryptography.X509Certificates;

namespace MiniBlogProject.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();

        public DbSet<Post> Posts => Set<Post>();

        public DbSet<Comment> Comments => Set<Comment>();
    }
}
