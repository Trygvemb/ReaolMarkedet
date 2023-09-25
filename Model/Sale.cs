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
        public string AssociatedBarcodeInNumbers { get; }
        public double Price { get; set; }
        public double DiscountInPercentage { get; }
        public double PriceOfSale { get; private set; }

        
        private static int count = 0;

        // Constructor for Sale
        public Sale(Barcode associatedBarcode, double price)
        {
            count++;
            SaleId = count;
            AssociatedBarcode = associatedBarcode;
            AssociatedBarcodeInNumbers = associatedBarcode.BarcodeInNumbers;
            Price = price;
            DiscountInPercentage = associatedBarcode.DiscountInPercentage;
            PriceOfSale = SubtractDiscount();
        }
        public Sale(int saleId, Barcode associatedBarcode, double price, double discountInPercentage, double priceOfSale)
        {
            SaleId = saleId;
            AssociatedBarcode = associatedBarcode;
            AssociatedBarcodeInNumbers = associatedBarcode.BarcodeInNumbers;
            Price = price;
            DiscountInPercentage = discountInPercentage;
            PriceOfSale = priceOfSale;

        }
        // Calculate the price of sale by subtracting discount
        private double SubtractDiscount()
        {
            PriceOfSale = Price - (Price * (DiscountInPercentage / 100));
            return PriceOfSale;
        }
    }
}
