using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HandyBusiness.Models
{
    public class HylemDbContext : DbContext
    {
        public HylemDbContext(DbContextOptions<HylemDbContext> options) 
            : base(options)
        {
           
        }

        public DbSet<Business> businesses { get; set; }
        public DbSet<Sector> businessSectors { get; set; }
        public DbSet<BusinessPhotos> businessPhotos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Sector> sector = new List<Sector>();

            sector.Add(new Sector() {
                Id = 1,
                ChargesPerHour = 200.00,
                OperatingMonth = 3,
                OperatingYear = 2,
                SectorName = "Woodwords"
            });

            sector.Add(new Sector() {
                Id = 2,
                ChargesPerHour = 400.00,
                OperatingMonth = 5,
                OperatingYear = 2,
                SectorName = "Woodwords"
            });

            //modelBuilder.Entity<Business>().HasRequired<Sector>()
            
            //modelBuilder.Entity<Business>().HasMany(s => s.Sectors);
        }
    }
}
