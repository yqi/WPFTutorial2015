using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCodeFirstSQLExpress.Models
{
    public class Student
    {
        public Student()
        {

        }

        #region properties
        public int Id { get; set; }
        public string Name { get; set; }


        public IList<Course> Courses{ get; set; }
        #endregion
    }
}
