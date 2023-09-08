﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaolMarkedet
{
    internal class Barcode
    {
        public string BarcodeInNumbers { get; set; }
        public List<Sale> Sales { get; } = new List<Sale>();

        // used to generate a new number for barcode as example and would get removed after implementing existing barcode generatot
        private static int count = 0;

        // constructor for Barcode. BarcodeInNumbers is used as example. Implementation of existing barcode generator goes in here
        public Barcode()
        {            
            count++;
            BarcodeInNumbers = $"{count}";
        }
        public void AddSale(Sale sale)
        {
            Sales.Add(sale);
        }
        public double GetTotalSalesAmount()
        {
            double totalSalesAmount = 0;

            foreach (Sale sale in Sales)
            {
                totalSalesAmount += sale.Price;
            }

            return totalSalesAmount;
        }


    }
}