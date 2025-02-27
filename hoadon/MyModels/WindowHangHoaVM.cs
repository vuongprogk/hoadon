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
    class WindowHangHoaVM : CBaseMVVM
    {
        public List<Hanghoa> m_listHangHoa { get; set; }
        public List<Hanghoa> Hanghoas
        {
            get { return m_listHangHoa; }
            set
            {
                m_listHangHoa = value;
                NotifyPropertyChanged("Hanghoas");
            }
        }
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
            var db = new hoadonContext();
            db.Hanghoas.Remove(SelectionHangHoa);
            db.SaveChanges();
            Hanghoas = db.Hanghoas.ToList();

        }
        public bool DeleteCanExecute(object parameter)
        {
            if (SelectionHangHoa == null)
            {
                return false;
            }
            var db = new hoadonContext();
            var cthd = db.Chitiethoadons.Where(p => p.Mahang == SelectionHangHoa.Mahang).FirstOrDefault();
            if (cthd != null)
            {
                return false;
            }
            return true;
        }

    }
}
