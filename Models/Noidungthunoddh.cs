using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsStore.Models
{
    public partial class Noidungthunoddh
    {
        public int Idndtnddh { get; set; }
        public int Idptnkh { get; set; }
        public int Iddh { get; set; }
        public DateTime Ngaythuno { get; set; }
        public float? Sotien { get; set; }
        public string Ghichu { get; set; }

        public virtual Dondathang IddhNavigation { get; set; }
        public virtual Phieuthunokh IdptnkhNavigation { get; set; }
    }
}
