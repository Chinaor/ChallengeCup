using ChallengeCup.Models;
using Microsoft.EntityFrameworkCore;

namespace ChallengeCup.Data
{
    public class ChallengeCupDbContext:DbContext
    {
        public DbSet<User> User { get; set; }

        public DbSet<Doctor> Doctor { get; set; }

        public DbSet<History> History { get; set; }

        public DbSet<Medicine> Medicine { get; set; }

        public DbSet<MedicineOrder> MedicineOrder { get; set; }

        public DbSet<Order> Order { get; set; }

        public ChallengeCupDbContext(DbContextOptions<ChallengeCupDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
