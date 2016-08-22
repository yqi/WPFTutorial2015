using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstSQLExpress.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base()
        {

        }

        #region properties
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Course> Course { get; set; }
        #endregion
    }
}
