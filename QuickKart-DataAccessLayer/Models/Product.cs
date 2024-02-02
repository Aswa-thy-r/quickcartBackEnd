using System;
using System.Collections.Generic;
using System.Text;

namespace QuickKart_DataAccessLayer.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public string Vendor { get; set; }

        public double Discount { get; set; }

        public string ProductImage { get; set; }


    }
}
