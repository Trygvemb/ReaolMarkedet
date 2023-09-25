﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaolMarkedet.Model
{
    internal class Barcode
    {
        public int AssociatedShelfTenantId { get; }
        public string BarcodeInNumbers { get; set; }
        public double DiscountInPercentage { get; private set; }
        public List<Sale> Sales { get; } = new List<Sale>();

        // Constructor for Barcode. BarcodeInNumbers is used as example. Implementation of existing barcode generator goes in here
        public Barcode(string barcodeInNumbers)
        {
            BarcodeInNumbers = barcodeInNumbers;
            DiscountInPercentage = 0;
        }
        // Overload for construtor with associatedShelfTenant
        public Barcode(int associatedShelfTenantId, string barcodeInNumbers)
        {
            AssociatedShelfTenantId = associatedShelfTenantId;
            BarcodeInNumbers = barcodeInNumbers;
            DiscountInPercentage = 0;
        }
        // Overload for construtor with associatedShelfTenant and discountInPercentage used when retreiving data from DB
        public Barcode(int associatedShelfTenantId, string barcodeInNumbers, double discountInPercentage)
        {
            AssociatedShelfTenantId = associatedShelfTenantId;
            BarcodeInNumbers = barcodeInNumbers;
            DiscountInPercentage = discountInPercentage;
        }

        // Adds sale to the list of sales 
        public void AddSale(Sale sale)
        {
            Sales.Add(sale);
        }
        // Calculate the total sales amount by going trough each sale in the list of sales and adding the price of sales together
        public double GetTotalSalesAmount()
        {
            double totalSalesAmount = 0;

            foreach (Sale sale in Sales)
            {
                totalSalesAmount += sale.PriceOfSale;
            }

            return totalSalesAmount;
        }
        // Sets discount
        public void SetDiscount(double discountInPercentage)
        {
            DiscountInPercentage = discountInPercentage;
        }


    }
}
