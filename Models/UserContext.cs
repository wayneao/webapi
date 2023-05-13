using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WebAPI.Models;

public class UserContext : DbContext
{
    private readonly IConfiguration Configuration;

    public UserContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));

    public DbSet<User> User { get; set; } = null!;
}