using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaolMarkedet
{
    internal class Sale
    {
        public Barcode AssociatedBarcode { get; }
        public double Price { get; set; }
        public double DiscountInPercentage { get; }
        public double PriceOfSale { get; private set; }


        public Sale(Barcode associatedBarcode, double price)
        {
            AssociatedBarcode = associatedBarcode;
            Price = price;
            DiscountInPercentage = associatedBarcode.DiscountInPercentage;
            PriceOfSale = SubtractDiscount();
        }
        private double SubtractDiscount()
        {
            PriceOfSale = Price - (Price * (DiscountInPercentage / 100));
            return PriceOfSale;
        }
    }
}
