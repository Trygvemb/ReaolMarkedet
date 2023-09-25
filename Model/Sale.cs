using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReaolMarkedet.Model;

namespace ReaolMarkedet
{
    internal class Sale
    {
        public int SaleId { get; set; } 
        public Barcode AssociatedBarcode { get; }
        public double Price { get; set; }
        public double DiscountInPercentage { get; }
        public double PriceOfSale { get; private set; }
        static int count = 0;

        // Constructor for Sale
        public Sale(Barcode associatedBarcode, double price)
        {
            count++;
            SaleId = count;
            AssociatedBarcode = associatedBarcode;
            Price = price;
            DiscountInPercentage = associatedBarcode.DiscountInPercentage;
            PriceOfSale = SubtractDiscount();
        }
        public Sale(int saleId, Barcode associatedBarcode, double price)
        {
            SaleId = saleId;
            AssociatedBarcode = associatedBarcode;
            Price = price;
            DiscountInPercentage = associatedBarcode.DiscountInPercentage;
            PriceOfSale = SubtractDiscount();

        }
        // Calculate the price of sale by subtracting discount
        private double SubtractDiscount()
        {
            PriceOfSale = Price - (Price * (DiscountInPercentage / 100));
            return PriceOfSale;
        }
    }
}
