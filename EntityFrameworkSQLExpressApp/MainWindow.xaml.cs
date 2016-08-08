using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EntityFrameworkSQLExpressApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ClassDbEntities entities;
        public MainWindow()
        {
            InitializeComponent();

            entities = new ClassDbEntities();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            EntityFrameworkSQLExpressApp.ClassDbDataSet classDbDataSet = ((EntityFrameworkSQLExpressApp.ClassDbDataSet)(this.FindResource("classDbDataSet")));
            // Load data into the table Student. You can modify this code as needed.
            EntityFrameworkSQLExpressApp.ClassDbDataSetTableAdapters.StudentTableAdapter classDbDataSetStudentTableAdapter = new EntityFrameworkSQLExpressApp.ClassDbDataSetTableAdapters.StudentTableAdapter();
            classDbDataSetStudentTableAdapter.Fill(classDbDataSet.Student);
            System.Windows.Data.CollectionViewSource studentViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("studentViewSource")));
            studentViewSource.View.MoveCurrentToFirst();
        }
    }
}
