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
        public SchoolContext() : base("SchoolDb")
        {
            //Database.SetInitializer<SchoolContext>(new CreateDatabaseIfNotExists<SchoolContext>());
            //Database.SetInitializer<SchoolContext>(new DropCreateDatabaseIfModelChanges<SchoolContext>());
            //Database.SetInitializer<SchoolContext>(new DropCreateDatabaseAlways<SchoolContext>());
            Database.SetInitializer(new SchoolDBInitializer());
        }

        #region properties
        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Course> Course { get; set; }
        #endregion
    }
    public class SchoolDBInitializer : DropCreateDatabaseAlways<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            IList<Student> defaultStudents = new List<Student>();
            defaultStudents.Add(new Student() { Id = 1, Name="David" });
            defaultStudents.Add(new Student() { Id = 2, Name = "Catherine" });
            foreach (Student student in defaultStudents)
                context.Student.Add(student);

            IList<Teacher> defaultTeachers = new List<Teacher>();
            defaultTeachers.Add(new Teacher() { Id = 1, Name = "Tom" });
            defaultTeachers.Add(new Teacher() { Id = 2, Name = "Jeff" });
            foreach (Teacher teacher in defaultTeachers)
                context.Teacher.Add(teacher);

            IList<Course> defaultCourses = new List<Course>();
            defaultCourses.Add(new Course() { Id = 1, Name = "Math" });
            defaultCourses.Add(new Course() { Id = 2, Name = "Science" });
            defaultCourses.Add(new Course() { Id = 3, Name = "Language" });
            foreach (Course course in defaultCourses)
                context.Course.Add(course);

            base.Seed(context);
        }
    }
}
