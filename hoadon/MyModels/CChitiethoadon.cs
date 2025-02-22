using hoadon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hoadon.MyModels
{
    class CChitiethoadon
    {
        public string Sohd { get; set; } = string.Empty;
        public string Mahang { get; set; }
        public double? Dongia { get; set; }
        public int? Soluong { get; set; } = 1;
        public string Tenhang
        {
            get
            {
                if (MahangNavigation == null)
                {
                    return string.Empty;
                }
                return MahangNavigation.Tenhang;
            }
        }
        public double? Thanhtien
        {
            get
            {
                if (!Dongia.HasValue || !Soluong.HasValue)
                {
                    return 0;
                }
                return Dongia.Value * Soluong.Value;
            }
        }
        public string Dvt
        {
            get
            {
                if (MahangNavigation == null)
                {
                    return string.Empty;
                }
                return MahangNavigation.Dvt;
            }
        }
        public Hanghoa MahangNavigation { get; set; }
        public static CChitiethoadon FromChitiethoadon(Chitiethoadon c)
        {
            return new CChitiethoadon
            {
                Sohd = c.Sohd,
                Mahang = c.Mahang,
                Dongia = c.Dongia,
                Soluong = c.Soluong,
                MahangNavigation = c.MahangNavigation
            };
        }
        public static Chitiethoadon ToChitiethoadon(CChitiethoadon c)
        {
            return new Chitiethoadon
            {
                Sohd = c.Sohd,
                Mahang = c.Mahang,
                Dongia = c.Dongia,
                Soluong = c.Soluong,
            };
        }
    }
}
