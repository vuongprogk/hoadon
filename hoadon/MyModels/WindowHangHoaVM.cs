using hoadon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoadon.MyModels
{
    class WindowHangHoaVM
    {
        public List<Hanghoa> Hanghoas { get; set; }
        public Hanghoa SelectionHangHoa { get; set; }
        public WindowHangHoaVM()
        {
            hoadonContext db = new hoadonContext();
            Hanghoas = db.Hanghoas.ToList();

        }
    }
}
