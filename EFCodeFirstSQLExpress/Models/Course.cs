using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstSQLExpress.Models
{
    public class Course
    {
        public Course()
        {

        }

        #region properties
        public int Id { get; set; }
        public string Name { get; set;}

        public Teacher Teacher{ get; set; }
        public IList<Student> Students { get; set; }
        #endregion
    }
}
