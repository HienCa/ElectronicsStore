using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsStore.Models
{
    public partial class Hanghoa
    {
        public Hanghoa()
        {
            Noidungddh = new HashSet<Noidungddh>();
            Noidungpnk = new HashSet<Noidungpnk>();
            Noidungpxk = new HashSet<Noidungpxk>();
        }

        public int Idhh { get; set; }
        public string Mavl { get; set; }
        public string Tenvl { get; set; }
        public string Hinhanh { get; set; }
        public float? Giakm { get; set; }
        public float Giaban { get; set; }
        public int Tinhtrang { get; set; }
        public string Mausac { get; set; }
        public string Donvitinh { get; set; }
        public int Thoigianbh { get; set; }
        public string Mota { get; set; }
        public int Active { get; set; }
        public int Idnsx { get; set; }
        public int Idth { get; set; }
        public int Idnhh { get; set; }

        public virtual Nhomhh IdnhhNavigation { get; set; }
        public virtual Nuosx IdnsxNavigation { get; set; }
        public virtual Thuonghieu IdthNavigation { get; set; }
        public virtual ICollection<Noidungddh> Noidungddh { get; set; }
        public virtual ICollection<Noidungpnk> Noidungpnk { get; set; }
        public virtual ICollection<Noidungpxk> Noidungpxk { get; set; }
    }
}
