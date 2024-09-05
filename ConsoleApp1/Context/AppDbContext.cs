using ConsoleApp1;
using Microsoft.EntityFrameworkCore;

    public class AppDbContext : DbContext
    {
        private object options;

        public AppDbContext(object options)
        {
            this.options = options;
        }

        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=testdb;User=root;Password=root;",
                new MySqlServerVersion(new Version(8, 0, 23)));
        }
    }
