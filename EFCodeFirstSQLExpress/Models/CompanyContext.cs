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
        public CompanyContext() : base("CompanyDb")
        {
        }

        // using connection string is like bellow for local SQL Server:
        //  <connectionStrings>
        //      <add name = "SchoolDBConnectionString"
        //      connectionString="Data Source=.;Initial Catalog=SchoolDb-ByConnectionString;Integrated Security=true" 
        //      providerName="System.Data.SqlClient"/>
        //  </connectionStrings>
        //public CompanyContext() : base("name=SchoolDbConnectionString")
        //{
        //}

        #region properties
        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Order> Order { get; set; }
        #endregion
    }
}
