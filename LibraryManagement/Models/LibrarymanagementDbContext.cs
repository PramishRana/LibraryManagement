using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Models
{
    public class LibrarymanagementDbContext:DbContext
    {
        public LibrarymanagementDbContext(DbContextOptions<LibrarymanagementDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string)))
            {
                property.SetColumnType("text");  // or "varchar"
            }

            // Other model configurations...
        }
    }
}
