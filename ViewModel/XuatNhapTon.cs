using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.ViewModel
{
    public class XuatNhapTon
    {
        public int Idhh { get; set; }
        public string Mahh { get; set; }
        public string Tenhh { get; set; }
        public string Donvitinh { get; set; }
        public float Soluongdauky { get; set; }
        public float Dongiadauky { get; set; }

        public float Soluonggiuakynhap { get; set; }
        public float Dongiagiuakynhap { get; set; }
        public float Soluonggiuakyxuat { get; set; }
        public float Dongiagiuakyxuat { get; set; }

        public float Soluongcuoiky { get; set; }
        public float Dongiacuoiky { get; set; }
        public float Tongtien { get; set; }
    }
}
