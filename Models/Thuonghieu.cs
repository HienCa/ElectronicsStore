using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsStore.Models
{
    public partial class Thuonghieu
    {
        public Thuonghieu()
        {
            Hanghoa = new HashSet<Hanghoa>();
        }

        public int Idth { get; set; }
        public string Math { get; set; }
        public string Tenth { get; set; }
        public int Active { get; set; }

        public virtual ICollection<Hanghoa> Hanghoa { get; set; }
    }
}
