using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstSQLExpress.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() : base()
        {
        }

        #region properties
        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        #endregion
    }
}
