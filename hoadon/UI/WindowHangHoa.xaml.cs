using hoadon.Models;
using System.Windows;
using System.Windows.Input;

namespace hoadon.UI
{
    /// <summary>
    /// Interaction logic for WindowHangHoa.xaml
    /// </summary>
    public partial class WindowHangHoa : Window
    {
        public static readonly RoutedUICommand command = new();
        public WindowHangHoa()
        {
            InitializeComponent();
            
        }

        private void Window_Load(object sender, RoutedEventArgs e)
        {
            var db = new hoadonContext();
            dataGridHangHoa.ItemsSource = db.Hanghoas.ToList();
        }


        private void execute_Them(object sender, ExecutedRoutedEventArgs e)
        {
            var hh = dataHangHoa.DataContext as Hanghoa;
            var db = new hoadonContext();
            db.Hanghoas.Add(hh);
            db.SaveChanges();
            dataGridHangHoa.ItemsSource = db.Hanghoas.ToList();
        }

        private void canExecute_Them(object sender, CanExecuteRoutedEventArgs e)
        {
            var hh = dataHangHoa.DataContext as Hanghoa;
            var db = new hoadonContext();
            if (hh == null || hh.Mahang is null || hh.Tenhang is null || hh.Dongia is null || hh.Dvt is null)
            {
                e.CanExecute = false;
                return;
            }
            e.CanExecute = true;
        }
    }
}
