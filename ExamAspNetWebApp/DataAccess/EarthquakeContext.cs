using ExamAspNetWebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamAspNetWebApp.DataAccess
{
    public class EarthquakeContext :DbContext
    {
        public EarthquakeContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Earthquake> Earthquakes { get; set; }
    }
}
