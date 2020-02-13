using Microsoft.EntityFrameworkCore;
using Crowdfund.Core.Model;

namespace Crowdfund_TeamProject.Data
{
    public class Crowdfund_TeamProjectDbContext : DbContext
    {
        private readonly string connectionString_;

        public Crowdfund_TeamProjectDbContext() : base()
        {
            connectionString_ = "Server=localhost;Database=Crowdfund;User Id=sa;Password=QWE123!@#";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(connectionString_);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.
                Entity<Backer>().
                ToTable("Backer");
        }
    }
}
