using Common.ViewModels;
using EFCodeFirstSQLExpress.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EFCodeFirstSQLExpress.ViewModels
{
    public class CodeFirstDemoVM : ViewModelBase
    {
        public CodeFirstDemoVM()
        {

        }
        #region properties

        SchoolContext _SchoolDbContext;
        public SchoolContext SchoolDbContext
        {
            get
            {
                if (_SchoolDbContext == null)
                {
                    _SchoolDbContext = new SchoolContext();
                    _SchoolDbContext.Student.Load();
                    _SchoolDbContext.Teacher.Load();
                    _SchoolDbContext.Course.Load();
                }

                return _SchoolDbContext;
            }
        }

        CompanyContext _CompanyDbContext;
        public CompanyContext CompanyDbContext
        {
            get
            {
                if (_CompanyDbContext == null)
                {
                    _CompanyDbContext = new CompanyContext();
                }

                return _CompanyDbContext;
            }
        }

        string _StudentName = string.Empty;
        public string StudentName
        {
            get
            {
                return _StudentName;
            }
            set
            {
                if (_StudentName != value)
                {
                    _StudentName = value;
                    RaisePropertyChanged(nameof(StudentName));
                }
            }
        }

        string _TeacherName = string.Empty;
        public string TeacherName
        {
            get
            {
                return _TeacherName;
            }
            set
            {
                if (_TeacherName != value)
                {
                    _TeacherName = value;
                    RaisePropertyChanged(nameof(TeacherName));
                }
            }
        }

        string _CourseName = string.Empty;
        public string CourseName
        {
            get
            {
                return _CourseName;
            }
            set
            {
                if (_CourseName != value)
                {
                    _CourseName = value;
                    RaisePropertyChanged(nameof(CourseName));
                }
            }
        }
        #endregion
        #region commands
        #region public
        ICommand _CreateScoolDBCommand;
        public ICommand CreateScoolDBCommand
        {
            get
            {
                if (_CreateScoolDBCommand == null)
                {
                    _CreateScoolDBCommand = new RelayCommand<string>((param) => { OnCreateScoolDBCommand(param); },
                                                              (param) => { return true; });
                }
                return _CreateScoolDBCommand;
            }
        }

        ICommand _CreateCompanyDBCommand;
        public ICommand CreateCompanyDBCommand
        {
            get
            {
                if (_CreateCompanyDBCommand == null)
                {
                    _CreateCompanyDBCommand = new RelayCommand<string>((param) => { OnCreateCompanyDBCommand(param); },
                                                              (param) => { return true; });
                }
                return _CreateCompanyDBCommand;
            }
        }

        ICommand _InsertCommand;
        public ICommand InsertCommand
        {
            get
            {
                if (_InsertCommand == null)
                {
                    _InsertCommand = new RelayCommand<string>((param) => { OnInsertCommand(param); },
                                                              (param) => { return true; });
                }
                return _InsertCommand;
            }
        }

        ICommand _DeleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_DeleteCommand == null)
                {
                    _DeleteCommand = new RelayCommand<string>((param) => { OnDeleteCommand(param); },
                                                              (param) => { return true; });
                }
                return _DeleteCommand;
            }
        }

        #endregion
        #region private
        void OnCreateScoolDBCommand(string param)
        {
        }
        void OnCreateCompanyDBCommand(string param)
        {

        }
        void OnInsertCommand(string param)
        {
            using (var ctx = new SchoolContext())
            {
                if (param == "Student")
                {
                    ctx.Student.Add(new Student() { Name = "Jerry" });
                    ctx.SaveChanges();
                }
                else if (param == "Teacher")
                {
                    ctx.Teacher.Add(new Teacher() { Name = "Kim" });
                    ctx.SaveChanges();
                }
                else if (param == "Course")
                {
                    ctx.Course.Add(new Course() { Name = "Biology" });
                    ctx.SaveChanges();
                }
                else
                {
                    ;
                }
            }
        }

        void OnDeleteCommand(string param)
        {
            using (var ctx = new SchoolContext())
            {
                if (param == "Student")
                {
                    Student student = ctx.Student.FirstOrDefault(s => s.Name == "Lisa");
                    if (student != null)
                        ctx.Student.Remove(student);
                    student = ctx.Student.FirstOrDefault(s => s.Name == "Jerry");
                    if (student != null)
                        ctx.Student.Remove(student);
                    ctx.SaveChanges();
                }
                else if (param == "Teacher")
                {
                    Teacher teacher = ctx.Teacher.FirstOrDefault(t => t.Name == "Clause");
                    ctx.Teacher.Remove(teacher);
                    ctx.SaveChanges();
                }
                else if (param == "Course")
                {
                    Course course = ctx.Course.FirstOrDefault(c => c.Name == "Arts");
                    ctx.Course.Remove(course);
                    ctx.SaveChanges();
                }
                else
                {
                    ;
                }
            }
        }
        #endregion
        #endregion
    }
}
