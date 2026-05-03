using BioTime.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BioTime
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}