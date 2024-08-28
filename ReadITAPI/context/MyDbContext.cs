using Microsoft.EntityFrameworkCore;

namespace ReadITAPI.Models
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Book> books { get; set; } //book:column , books:table_name
        public DbSet<Category> categories { get; set; }
        public DbSet<ApplicationUser> users { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Publisher> publishers { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public DbSet<Requstion> Requstions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
