using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsStore.Models
{
    public partial class Phieuthunokh
    {
        public Phieuthunokh()
        {
            Noidungthunoddh = new HashSet<Noidungthunoddh>();
        }

        public int Idptnkh { get; set; }
        public string Sophieu { get; set; }
        public DateTime Ngaylap { get; set; }
        public string Ghichu { get; set; }
        public int Active { get; set; }
        public int Idhttt { get; set; }
        public int Idnv { get; set; }

        public virtual Hinhthucthanhtoan IdhtttNavigation { get; set; }
        public virtual Nhanvien IdnvNavigation { get; set; }
        public virtual ICollection<Noidungthunoddh> Noidungthunoddh { get; set; }
    }
}
