using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsStore.Models
{
    public partial class Noidungtranoncc
    {
        public int Idndtnncc { get; set; }
        public int Idptnncc { get; set; }
        public int Idpnk { get; set; }
        public float? Sotien { get; set; }
        public DateTime? Ngaytrano { get; set; }
        public string Ghichu { get; set; }

        public virtual Phieunhapkho IdpnkNavigation { get; set; }
        public virtual Phieutranoncc IdptnnccNavigation { get; set; }
    }
}
