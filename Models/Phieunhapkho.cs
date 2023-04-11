using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsStore.Models
{
    public partial class Phieunhapkho
    {
        public Phieunhapkho()
        {
            Noidungpnk = new HashSet<Noidungpnk>();
            Noidungtranoncc = new HashSet<Noidungtranoncc>();
        }

        public int Idpnk { get; set; }
        public string Sophieu { get; set; }
        public DateTime Ngaylap { get; set; }
        public string Sohd { get; set; }
        public DateTime? Ngayhd { get; set; }
        public string Ghichu { get; set; }
        public int Active { get; set; }
        public int Idncc { get; set; }
        public int Idnv { get; set; }

        public virtual Nhacungcap IdnccNavigation { get; set; }
        public virtual Nhanvien IdnvNavigation { get; set; }
        public virtual ICollection<Noidungpnk> Noidungpnk { get; set; }
        public virtual ICollection<Noidungtranoncc> Noidungtranoncc { get; set; }
    }
}
