using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsStore.Models
{
    public partial class Noidungddh
    {
        public int Idndddh { get; set; }
        public float Soluong { get; set; }
        public float Dongia { get; set; }
        public DateTime? Hethanbh { get; set; }
        public int Idhh { get; set; }
        public int Iddh { get; set; }

        public virtual Dondathang IddhNavigation { get; set; }
        public virtual Hanghoa IdhhNavigation { get; set; }
    }
}
