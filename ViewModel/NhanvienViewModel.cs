using ElectronicsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.ViewModel
{
    public class NhanvienViewModel : EditImageViewModel
    {
        public NhanvienViewModel()
        {
            Phieunhapkho = new HashSet<Phieunhapkho>();
            Phieuthunokh = new HashSet<Phieuthunokh>();
            Phieutranoncc = new HashSet<Phieutranoncc>();
        }

        public int Idnv { get; set; }
        public string Manv { get; set; }
        public string Tennv { get; set; }
        public string Cccd { get; set; }
        public DateTime Ngaysinh { get; set; }
        public string Gioitinh { get; set; }
        public string Diachi { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string Masothue { get; set; }
        public string Matkhau { get; set; }
        //public string Hinhanh { get; set; }
        public string Ghichu { get; set; }
        public string Facebook { get; set; }
        public string Zalo { get; set; }
        public int Active { get; set; }

        public virtual ICollection<Phieunhapkho> Phieunhapkho { get; set; }
        public virtual ICollection<Phieuthunokh> Phieuthunokh { get; set; }
        public virtual ICollection<Phieutranoncc> Phieutranoncc { get; set; }
    }
}
