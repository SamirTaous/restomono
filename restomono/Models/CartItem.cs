using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restomono.Models
{
    public class CartItem
    {
        public Plat Plat { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice => Quantity * Plat.Price;
    }
}
