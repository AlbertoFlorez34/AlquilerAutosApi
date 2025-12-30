using Microsoft.EntityFrameworkCore;
using AlquilerAutosApi.Models;
using System.Collections.Generic;

namespace AlquilerAutosApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Auto> Autos => Set<Auto>();
    }
}
