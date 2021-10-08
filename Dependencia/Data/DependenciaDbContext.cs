using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Dependencia.Data
{
    public class DependenciaDbContext : DbContext
    {
        public DependenciaDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Dependencia.Models.Dependencia> dependencias { get; set; }

    }
}
