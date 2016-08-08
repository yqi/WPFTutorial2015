using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace EntityFrameworkSQLExpressApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (ClassDbEntities entities = new ClassDbEntities())
            {
                entities.Students.Load();
                dataGrid.ItemsSource = entities.Students.Local;
            }
        }
    }
}
