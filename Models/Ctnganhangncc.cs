using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsStore.Models
{
    public partial class Ctnganhangncc
    {
        public int Idctnhncc { get; set; }
        public int Stk { get; set; }
        public int Idnh { get; set; }
        public int Idncc { get; set; }

        public virtual Nhacungcap IdnccNavigation { get; set; }
        public virtual Nganhang IdnhNavigation { get; set; }
    }
}
