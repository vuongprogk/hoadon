using hoadon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoadon.MyModels
{
    class CHoadon
    {
        public CHoadon()
        {
            Chitiethoadons = new HashSet<CChitiethoadon>();
        }

        public string Sohd { get; set; }
        public DateTime? Ngaylaphd { get; set; }
        public string Tenkh { get; set; }
        public double? Thanhtien
        {
            get
            {
                return Chitiethoadons.Sum(c => c.Thanhtien);
            }
        }

        public ICollection<CChitiethoadon> Chitiethoadons { get; set; }
        public static CHoadon FromHoadon(Hoadon h)
        {
            return new CHoadon
            {
                Sohd = h.Sohd,
                Ngaylaphd = h.Ngaylaphd,
                Tenkh = h.Tenkh,
                Chitiethoadons = h.Chitiethoadons.Select(c => CChitiethoadon.FromChitiethoadon(c)).ToList()
            };
        }
        public static Hoadon ToHoadon(CHoadon c)
        {
            return new Hoadon
            {
                Sohd = c.Sohd,
                Ngaylaphd = c.Ngaylaphd,
                Tenkh = c.Tenkh,
                Chitiethoadons = c.Chitiethoadons.Select(c => CChitiethoadon.ToChitiethoadon(c)).ToList()
            };
        }
    }
}
