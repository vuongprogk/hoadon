using hoadon.Models;
using hoadon.MyModels;
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
using System.Windows.Shapes;

namespace hoadon.UI
{
    /// <summary>
    /// Interaction logic for WindowHoaDon.xaml
    /// </summary>
    public partial class WindowHoaDon : Window
    {
        public WindowHoaDon()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            hoadonContext db = new hoadonContext();
            dgHoaDon.ItemsSource = db.Hoadons.ToList();
            cmbMahang.ItemsSource = db.Hanghoas.ToList();
        }

        private void dgHoaDon_LoadingRowDetails(object sender, DataGridRowDetailsEventArgs e)
        {
            var hd = e.Row.Item as Hoadon;
            var context = new hoadonContext();
            var cthd = context.Chitiethoadons.Where(p => p.Sohd == hd.Sohd).ToList();
            hd.Chitiethoadons = cthd;
            foreach (var item in cthd)
            {
                var hh = context.Hanghoas.Find(item.Mahang);
                item.MahangNavigation = hh;
            }
            var detailDataGrid = e.DetailsElement;
            var stackPanel = detailDataGrid.FindName("stackHoaDon") as StackPanel;
            stackPanel.DataContext = CHoadon.FromHoadon(hd);
        }
    }
}
