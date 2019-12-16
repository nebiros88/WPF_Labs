using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Lab_8_sol
{
    public class ProviderContext : DbContext
    {
        public ProviderContext() : base("DefaultConnection")
        {
        }

        public DbSet<Provider> Providers { get; set; }
    }
}
