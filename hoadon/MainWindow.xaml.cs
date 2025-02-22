using System.Windows;
using hoadon.UI;
namespace hoadon;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void menuHangHoa_Click(object sender, RoutedEventArgs e)
    {
        var f = new WindowHangHoa();
        f.Show();
    }

    private void menuHoaDon_Click(object sender, RoutedEventArgs e)
    {
        var f = new WindowHoaDon();
        f.Show();
    }
}