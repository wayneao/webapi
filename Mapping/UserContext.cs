using DemoWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DemoWeb.Mapping
{
    public partial class UserContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public UserContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public DbSet<User>? Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("users_pkey");

                entity.ToTable("users");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.Password)
                    .HasMaxLength(32)
                    .IsFixedLength()
                    .HasColumnName("password");
                entity.Property(e => e.Username)
                    .HasMaxLength(32)
                    .IsFixedLength()
                    .HasColumnName("username");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}