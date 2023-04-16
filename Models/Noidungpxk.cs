using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsStore.Models
{
    public partial class Noidungpxk
    {
        public int Idndpxk { get; set; }
        public float Soluong { get; set; }
        public float Dongia { get; set; }
        public float? Vat { get; set; }
        public float? Cktm { get; set; }
        public int Idpxk { get; set; }
        public int Idhh { get; set; }
        public string Donvitinh { get; set; }

        public virtual Hanghoa IdhhNavigation { get; set; }
        public virtual Phieuxuatkho IdpxkNavigation { get; set; }
    }
}
