using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsStore.Models
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Phieunhapkho = new HashSet<Phieunhapkho>();
            Phieuthunokh = new HashSet<Phieuthunokh>();
            Phieutranoncc = new HashSet<Phieutranoncc>();
            Phieuxuatkho = new HashSet<Phieuxuatkho>();
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
        public string Hinhanh { get; set; }
        public string Ghichu { get; set; }
        public string Facebook { get; set; }
        public string Zalo { get; set; }
        public int Active { get; set; }

        public virtual ICollection<Phieunhapkho> Phieunhapkho { get; set; }
        public virtual ICollection<Phieuthunokh> Phieuthunokh { get; set; }
        public virtual ICollection<Phieutranoncc> Phieutranoncc { get; set; }
        public virtual ICollection<Phieuxuatkho> Phieuxuatkho { get; set; }
    }
}
