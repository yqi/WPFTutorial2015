using EFDbFirstSQLExpress.ViewModels;
using System.Windows.Controls;

namespace EFDbFirstSQLExpress.Views
{
    /// <summary>
    /// Interaction logic for TablesCtrl.xaml
    /// </summary>
    public partial class TablesCtrl : UserControl
    {
        DbFirstDemoVM _vm;
        public TablesCtrl()
        {
            InitializeComponent();

            _vm = new DbFirstDemoVM();
            DataContext = _vm;
        }
    }
}
