using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsStore.Models
{
    public partial class Noidungpnk
    {
        public int Idndpnk { get; set; }
        public float Soluong { get; set; }
        public float Dongia { get; set; }
        public string Solo { get; set; }
        public DateTime? Ngaysx { get; set; }
        public DateTime? Hansd { get; set; }
        public float? Vat { get; set; }
        public float? Cktm { get; set; }
        public int Idhh { get; set; }
        public int Idpnk { get; set; }

        public virtual Hanghoa IdhhNavigation { get; set; }
        public virtual Phieunhapkho IdpnkNavigation { get; set; }
    }
}
