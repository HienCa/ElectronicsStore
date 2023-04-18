using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ElectronicsStore.Entities
{
    public partial class Report
    {
        
        public string Mavl { get; set; }
        public string Tenvl { get; set; }
        public string Donvitinh { get; set; }
        public DateTime Ngaylapbaocao { get; set; }
        public float SLdauky { get; set; }
        public float Giadauky { get; set; }
        public float Tongtiendauky { get; set; }
        public float SLnhaptrongky { get; set; }
        public float Gianhaptrongky { get; set; }
        public float Tongtiennhaptrongky { get; set; }
        public float SLxuattrongky { get; set; }
        public float Giaxuattrongky { get; set; }
        public float Tongtienxuattrongky { get; set; }
        public float SLtoncuoiky { get; set; }
        public float Giatoncuoiky { get; set; }
        public float Tongtientoncuoiky { get; set; }


    }
}
