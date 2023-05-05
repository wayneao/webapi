using DemoWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DemoWeb.Mapping
{
    class UsersContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public UsersContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<Users>? Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }
    }
}