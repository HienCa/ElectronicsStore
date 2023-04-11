using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsStore.Models
{
    public partial class Dondathang
    {
        public Dondathang()
        {
            Noidungddh = new HashSet<Noidungddh>();
            Noidungthunoddh = new HashSet<Noidungthunoddh>();
        }

        public int Iddh { get; set; }
        public string Madh { get; set; }
        public DateTime Ngaydat { get; set; }
        public DateTime? Ngaygiao { get; set; }
        public int Trangthai { get; set; }
        public string Ghichu { get; set; }
        public int Active { get; set; }
        public int Idkh { get; set; }

        public virtual Khachhang IdkhNavigation { get; set; }
        public virtual ICollection<Noidungddh> Noidungddh { get; set; }
        public virtual ICollection<Noidungthunoddh> Noidungthunoddh { get; set; }
    }
}
