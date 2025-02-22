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
        public static RoutedUICommand select = new RoutedUICommand();
        public static RoutedUICommand addContract = new RoutedUICommand();
        private CHoadon hd = new CHoadon();
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

        private void chon_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var ct = gridCTHD.DataContext as CChitiethoadon;
            var x = new CChitiethoadon()
            {
                Mahang = ct.Mahang,
                Soluong = ct.Soluong,
            };
            var context = new hoadonContext();
            x.MahangNavigation = context.Hanghoas.Find(x.Mahang);
            x.Dongia = x.MahangNavigation.Dongia;
            hd.Chitiethoadons.Add(x);
            //gdChitiet.ItemsSource = hd.Chitiethoadons.ToList();
            stackHoaDon.DataContext = CHoadon.Clone(hd);

        }

        private void chon_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void add_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var x = stackHoaDon.DataContext as CHoadon;
            var y = CHoadon.ToHoadon(x);
            var context = new hoadonContext();
            foreach(var c in y.Chitiethoadons)
            {
                c.Sohd = y.Sohd;
            }
            context.Hoadons.Add(y);
            context.SaveChanges();
            dgHoaDon.ItemsSource = context.Hoadons.ToList();
            hd = new CHoadon();
            stackHoaDon.DataContext = hd;

        }

        private void add_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
