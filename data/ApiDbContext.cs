using Microsoft.EntityFrameworkCore;
using PostgresDb.Models;

namespace PostgresDb.data
{
    public class ApiDbContext : DbContext
    {

        public DbSet<Team> Teams { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<DriverMedia> DriverMedias { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Driver>(entity =>
            {
                // one to many relationship between Team and Driver
                entity.HasOne(t => t.Team)
                    .WithMany(d => d.Drivers)
                    .HasForeignKey(x => x.TeamId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Driver_Team");

                // one to many relationship between Driver and DriverMedia
                entity.HasOne(
                    dm => dm.DriverMedia
                ).WithOne(d => d.Driver)
                .HasForeignKey<DriverMedia>(x => x.DriverId);
            });
        }
    }

}