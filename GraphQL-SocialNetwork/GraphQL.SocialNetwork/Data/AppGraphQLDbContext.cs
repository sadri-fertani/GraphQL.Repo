using GraphQL.SocialNetwork.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GraphQL.SocialNetwork.Data
{
    public class AppGraphQLDbContext : DbContext
    {
        private readonly IConfiguration _config;

        public AppGraphQLDbContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<SocialNet> SocialsNet { get; set; }
        public DbSet<Categorie> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
        }
    }
}