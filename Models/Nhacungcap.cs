using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsStore.Models
{
    public partial class Nhacungcap
    {
        public Nhacungcap()
        {
            Ctnganhangncc = new HashSet<Ctnganhangncc>();
            Phieunhapkho = new HashSet<Phieunhapkho>();
        }

        public int Idncc { get; set; }
        public string Mancc { get; set; }
        public string Tenncc { get; set; }
        public string Diachi { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
        public string Masothue { get; set; }
        public string Ghichu { get; set; }
        public string Facebook { get; set; }
        public string Zalo { get; set; }
        public int Active { get; set; }

        public virtual ICollection<Ctnganhangncc> Ctnganhangncc { get; set; }
        public virtual ICollection<Phieunhapkho> Phieunhapkho { get; set; }
    }
}
