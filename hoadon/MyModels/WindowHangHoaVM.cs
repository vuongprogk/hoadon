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
        private List<Hanghoa> m_listHangHoa { get; set; }
        public List<Hanghoa> Hanghoas
        {
            get { return m_listHangHoa; }
            set
            {
                m_listHangHoa = value;
                NotifyPropertyChanged("Hanghoas");
            }
        }
        private Hanghoa m_selectionHangHoa { get; set; }
        public Hanghoa SelectionHangHoa
        {
            get
            {
                return this.m_selectionHangHoa;
            }
            set
            {
                if (value != null)
                {
                    SetTextForm(mh: value.Mahang, tenhang: value.Tenhang, dvt: value.Dvt, dg: value.Dongia.ToString() ?? string.Empty);
                    this.m_selectionHangHoa = value;
                }
            }
        }
        public RelayCommand DeleteCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand UpdateCommand { get; set; }
        public string Mahang { get; set; }
        public string Tenhang { get; set; }
        public string Dvt { get; set; }
        public string Dongia { get; set; }
        public WindowHangHoaVM()
        {
            hoadonContext db = new hoadonContext();
            Hanghoas = db.Hanghoas.ToList();
            DeleteCommand = new RelayCommand(DeleteExecute, DeleteCanExecute);
            AddCommand = new RelayCommand(AddExecute, AddCanExecute);
            UpdateCommand = new RelayCommand(UpdateExecute, UpdateCanExecute);
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
        public void AddExecute(object parameter)
        {
            var db = new hoadonContext();
            Hanghoa hh = new Hanghoa();
            hh.Mahang = Mahang;
            hh.Tenhang = Tenhang;
            hh.Dvt = Dvt;
            hh.Dongia = Convert.ToDouble(Dongia);
            db.Hanghoas.Add(hh);

            db.SaveChanges();
            SetTextForm();
            Hanghoas = db.Hanghoas.ToList();
        }
        public bool AddCanExecute(object parameter)
        {
            double dg;
            if (string.IsNullOrEmpty(Mahang) || string.IsNullOrEmpty(Tenhang) || string.IsNullOrEmpty(Dvt) || string.IsNullOrEmpty(Dongia) || double.TryParse(Dongia, out dg) == false)
            {
                return false;
            }
            var db = new hoadonContext();
            var hh = db.Hanghoas.Where(p => p.Mahang == Mahang).FirstOrDefault();
            if (hh != null)
            {
                return false;
            }
            return true;
        }
        public void UpdateExecute(object parameter)
        {
            var db = new hoadonContext();
            var hh = db.Hanghoas.Where(p => p.Mahang == SelectionHangHoa.Mahang).FirstOrDefault();
            if (hh != null)
            {
                hh.Tenhang = Tenhang;
                hh.Dvt = Dvt;
                hh.Dongia = Convert.ToDouble(Dongia);
                db.SaveChanges();
                SetTextForm();
                Hanghoas = db.Hanghoas.ToList();
            }
        }
        public bool UpdateCanExecute(object parameter)
        {
            if (SelectionHangHoa == null || string.IsNullOrEmpty(Tenhang) || string.IsNullOrEmpty(Dvt) || string.IsNullOrEmpty(Dongia))
            {
                return false;
            }
            var db = new hoadonContext();
            var hh = db.Hanghoas.Where(p => p.Mahang == SelectionHangHoa.Mahang).FirstOrDefault();
            if (hh == null)
            {
                return false;
            }
            return true;
        }
        public void SetTextForm(string mh = "", string tenhang = "", string dvt = "", string dg = "")
        {
            Mahang = mh;
            Tenhang = tenhang;
            Dvt = dvt;
            Dongia = dg;
            NotifyPropertyChanged(nameof(Mahang));
            NotifyPropertyChanged(nameof(Tenhang));
            NotifyPropertyChanged(nameof(Dvt));
            NotifyPropertyChanged(nameof(Dongia));
            m_selectionHangHoa = null!;
        }

    }
}
