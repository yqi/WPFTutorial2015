using EntityFrameworkSQLExpressApp.ViewModels;
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

namespace EntityFrameworkSQLExpressApp.Views
{
    /// <summary>
    /// Interaction logic for DbFirstDemoCtrl.xaml
    /// </summary>
    public partial class DbFirstDemoCtrl : UserControl
    {
        DbFirstDemoVM _vm;
        public DbFirstDemoCtrl()
        {
            InitializeComponent();

            _vm = new DbFirstDemoVM();
            DataContext = _vm;
        }
    }
}
