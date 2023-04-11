using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsStore.Models
{
    public partial class Hinhthucthanhtoan
    {
        public Hinhthucthanhtoan()
        {
            Nganhang = new HashSet<Nganhang>();
            Phieuthunokh = new HashSet<Phieuthunokh>();
            Phieutranoncc = new HashSet<Phieutranoncc>();
        }

        public int Idhttt { get; set; }
        public string Mahttt { get; set; }
        public string Tenhttt { get; set; }
        public int Active { get; set; }

        public virtual ICollection<Nganhang> Nganhang { get; set; }
        public virtual ICollection<Phieuthunokh> Phieuthunokh { get; set; }
        public virtual ICollection<Phieutranoncc> Phieutranoncc { get; set; }
    }
}
