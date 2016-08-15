using System.Data.Entity;
using System.Linq;
using Common.ViewModels;
using System.Windows.Input;

namespace EFModelFirstSQLExpress.ViewModels
{
    public class DbFirstDemoVM : ViewModelBase
    {
        public DbFirstDemoVM()
        {
        }

        #region properties

        ModelFirstModelContainer _DbContext;
        public ModelFirstModelContainer DbContext
        {
            get
            {
                if (_DbContext == null)
                {
                    _DbContext = new ModelFirstModelContainer();
                    _DbContext.Student.Load();
                    _DbContext.Teacher.Load();
                    _DbContext.Course.Load();
                }

                return _DbContext;
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
                if(_TeacherName != value)
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
        void OnInsertCommand(string param)
        {
            if(param == "Student")
            {
                _DbContext.Student.Add(new Student() { Name = "Jerry" });
                _DbContext.Student.Add(new Student() { Name = "Lisa" });
                _DbContext.SaveChanges();
            }
            else if (param == "Teacher")
            {
                _DbContext.Teacher.Add(new Teacher() { Name = "Kim" });
                _DbContext.Teacher.Add(new Teacher() { Name = "Clause" });
                _DbContext.SaveChanges();
            }
            else if (param == "Course")
            {
                _DbContext.Course.Add(new Course() { Name = "Arts" });
                _DbContext.Course.Add(new Course() { Name = "Biology" });
                _DbContext.SaveChanges();
            }
            else
            {
                ;
            }
        }

        void OnDeleteCommand(string param)
        {
            if (param == "Student")
            {
                Student student = _DbContext.Student.FirstOrDefault(s => s.Name == "Lisa");
                if(student != null)
                    _DbContext.Student.Remove(student);
                student = _DbContext.Student.FirstOrDefault(s => s.Name == "Jerry");
                if (student != null)
                    _DbContext.Student.Remove(student);
                _DbContext.SaveChanges();
            }
            else if (param == "Teacher")
            {
                Teacher teacher = _DbContext.Teacher.FirstOrDefault(t => t.Name == "Clause");
                _DbContext.Teacher.Remove(teacher);
                _DbContext.SaveChanges();
            }
            else if (param == "Course")
            {
                Course course = _DbContext.Course.FirstOrDefault(c => c.Name == "Arts");
                _DbContext.Course.Remove(course);
                _DbContext.SaveChanges();
            }
            else
            {
                ;
            }
        }
        #endregion
        #endregion
    }
}
