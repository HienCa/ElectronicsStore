using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsStore.Models
{
    public partial class Phieuxuatkho
    {
        public Phieuxuatkho()
        {
            Noidungpxk = new HashSet<Noidungpxk>();
            Noidungthunokh = new HashSet<Noidungthunokh>();
        }

        public int Idpxk { get; set; }
        public string Sophieu { get; set; }
        public DateTime Ngaylap { get; set; }
        public string Sohd { get; set; }
        public DateTime? Ngayhd { get; set; }
        public string Ghichu { get; set; }
        public int Active { get; set; }
        public int Idnv { get; set; }
        public int Idkh { get; set; }

        public virtual Khachhang IdkhNavigation { get; set; }
        public virtual Nhanvien IdnvNavigation { get; set; }
        public virtual ICollection<Noidungpxk> Noidungpxk { get; set; }
        public virtual ICollection<Noidungthunokh> Noidungthunokh { get; set; }
    }
}
