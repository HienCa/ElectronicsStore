using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsStore.Models
{
    public partial class Nhomhh
    {
        public Nhomhh()
        {
            Hanghoa = new HashSet<Hanghoa>();
        }

        public int Idnhh { get; set; }
        public string Manhh { get; set; }
        public string Tennhh { get; set; }
        public int Active { get; set; }

        public virtual ICollection<Hanghoa> Hanghoa { get; set; }
    }
}
