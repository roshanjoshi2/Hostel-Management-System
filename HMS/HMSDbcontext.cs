using HMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HMS
{
    public class HMSDbcontext:DbContext
    {
        public DbSet<Hostel> Hostels { get; set; }
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Hostel;Integrated Security=true");
        }
    }
}
