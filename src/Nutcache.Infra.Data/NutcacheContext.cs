using Microsoft.EntityFrameworkCore;
using Nutcache.Domain.Entities;

namespace Nutcache.Infra.Data
{
    public class NutcacheContext : DbContext
    {
        public NutcacheContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
