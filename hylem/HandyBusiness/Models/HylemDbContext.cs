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
        public DbSet<Sector> sectors { get; set; }
        public DbSet<BusinessPhotos> businessPhotos { get; set; }
    }
}
