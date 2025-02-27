using hoadon.Models;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace hoadon.MyModels
{
    class WindowHangHoaVM
    {
        public List<Hanghoa> Hanghoas { get; set; }
        public Hanghoa SelectionHangHoa { get; set; } = default!;
        public RelayCommand DeleteCommand { get; set; }
        public WindowHangHoaVM()
        {
            hoadonContext db = new hoadonContext();
            Hanghoas = db.Hanghoas.ToList();
            DeleteCommand = new RelayCommand(DeleteExecute, DeleteCanExecute);

        }
        public void DeleteExecute(object parameter)
        {

        }
        public  bool DeleteCanExecute(object parameter)
        {
            return true;
        }
        
    }
}
