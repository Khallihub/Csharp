using Microsoft.EntityFrameworkCore;

namespace Blog.Data

{
    public class BlogDBContext : DbContext {
        public virtual DbSet<Entities.Comment> Comments { get; set; }
        public virtual DbSet<Entities.Post> Posts { get; set; }
        public BlogDBContext(DbContextOptions<BlogDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Entities.Comment>(entity => {
                entity.HasKey(e => e.CommentId);
                entity.Property(e => e.CommentId).ValueGeneratedOnAdd();
                entity.Property(e => e.PostId).IsRequired();
                entity.Property(e => e.Text).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired(); 
            });
            modelBuilder.Entity<Entities.Post>(entity => {
                entity.HasKey(e => e.PostId);
                entity.Property(e => e.PostId).ValueGeneratedOnAdd();
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.Content).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
            });
        }
    }

}