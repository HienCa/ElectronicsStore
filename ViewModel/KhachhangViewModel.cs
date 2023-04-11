using ElectronicsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.ViewModel
{
    public class KhachhangViewModel : EditImageViewModel
    {
        public KhachhangViewModel()
        {
            Ctnganhangkh = new HashSet<Ctnganhangkh>();
            Dondathang = new HashSet<Dondathang>();
        }

        public int Idkh { get; set; }
        public string Makh { get; set; }
        public string Tenkh { get; set; }
        public string Cccd { get; set; }
        public string Diachi { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string Matkhau { get; set; }
        public string Gioitinh { get; set; }
        public string Masothue { get; set; }
        public string Ghichu { get; set; }
        public int? Nvidsale { get; set; }
        //public string Hinhanh { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Facebook { get; set; }
        public string Zalo { get; set; }
        public int Active { get; set; }

        public virtual ICollection<Ctnganhangkh> Ctnganhangkh { get; set; }
        public virtual ICollection<Dondathang> Dondathang { get; set; }
    }
}
