using Microsoft.EntityFrameworkCore;
using PlaceChecklist.DbStuff.Models;

namespace PlaceChecklist.DbStuff
{
    public class WebDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Establishment> Establishments { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public WebDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Establishment>()
                .HasOne(Establishment => Establishment.Category)
                .WithMany(category => category.Establishments)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Establishment>()
               .HasMany(Establishment => Establishment.Tags)
               .WithMany(Tag => Tag.Establishments);

            base.OnModelCreating(builder);
        }
    }
}
