using ElectronicsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.ViewModel
{
    public class NoidungddhViewModel: Noidungddh
    {
        //status=0; hết hàng
        //status=1; còn hàng
        public string Tenhh { get; set; }
        public string Hinhanh { get; set; }
        public int Status { get; set; }
        public float SoLuongTon { get; set; }
        public float SoLuongThieu { get; set; }

    }

}
