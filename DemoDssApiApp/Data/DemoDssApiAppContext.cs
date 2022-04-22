using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DemoDssApiApp.Data
{
    public class DemoDssApiAppContext : DbContext
    {
        public DemoDssApiAppContext (DbContextOptions<DemoDssApiAppContext> options)
            : base(options)
        {
        }

        public DbSet<DemoDssApiApp.Data.Employee> Employee { get; set; }
    }
}
