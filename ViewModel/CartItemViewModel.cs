using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicsStore.ViewModel
{
    public class CartItemViewModel
    {
        public string productId { get; set; }
        public string productImage { get; set; }
        public string productName { get; set; }
        public string count { get; set; }
       
        public string productPrice { get; set; }
    }

}
