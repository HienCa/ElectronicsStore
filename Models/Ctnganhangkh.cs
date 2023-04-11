using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsStore.Models
{
    public partial class Ctnganhangkh
    {
        public int Idctnhkh { get; set; }
        public int Stk { get; set; }
        public int Idkh { get; set; }
        public int Idnh { get; set; }

        public virtual Khachhang IdkhNavigation { get; set; }
        public virtual Nganhang IdnhNavigation { get; set; }
    }
}
