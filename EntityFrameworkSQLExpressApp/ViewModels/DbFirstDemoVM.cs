using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ViewModels;
using System.Windows.Input;

namespace EntityFrameworkSQLExpressApp.ViewModels
{
    public class DbFirstDemoVM : ViewModelBase
    {
        public DbFirstDemoVM()
        {
        }

        #region properties

        ClassDbEntities _DbContext;
        public ClassDbEntities DbContext
        {
            get
            {
                if (_DbContext == null)
                {
                    _DbContext = new ClassDbEntities();
                    _DbContext.Students.Load();
                    _DbContext.Teachers.Load();
                    _DbContext.Courses.Load();
                    _DbContext.TeacherCourses.Load();
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

        void OnInsertCommand(string param)
        {
            if(param == "Student")
            {
                ;
            }
            else if (param == "Teacher")
            {
                ;
            }
            else if (param == "Course")
            {
                ;
            }
            else
            {
                ;
            }
        }
        #endregion
    }
}
