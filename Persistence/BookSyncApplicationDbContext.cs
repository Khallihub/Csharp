using Assessment.Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class BookAppDbContext : DbContext
    {
        public BookAppDbContext(DbContextOptions<BookAppDbContext> options)
            : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BookAppDbContext).Assembly);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {

          

            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public DbSet<Book> Movies { get; set; }
    }
}
