using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaolMarkedet
{
    internal class Sale
    {
        public string BarcodeInNumbers { get; }
        public double Price { get; set; }
        public double DiscountInPercentage { get; }
        public double PriceOfSale { get; set; }


        public Sale(string barcodeInNumbers, double price)
        {
            BarcodeInNumbers = barcodeInNumbers;
            Price = price;
        }
    }
}
