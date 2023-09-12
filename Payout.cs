﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaolMarkedet
{
    internal class Payout
    {
        private double _commission = 15; // default commission rate of 15%
        private double _fine = 0; // default fine of 0

        public double TotalPayout { get; set; }
        public string TenantId { get; set; }
        public double TotalSale { get; private set; }
        public double CommissionDeduction { get; private set; }
                        
        public double Commission
        {
            get { return _commission; }
            set { _commission = value; }
        }
        public double Fine 
        {
            get { return _fine; } 
            set { _fine = value; } 
        }

        public Payout(ShelfTenant shelfTenant, string barcodeInNumbers) 
        {
            
            foreach (Barcode barcode in shelfTenant.barcodes)
            {
                if (barcode.BarcodeInNumbers == barcodeInNumbers)
                {
                    // implementerer automatisk udbetaling
                    string shelfTenantDetails = "";
                    shelfTenantDetails = $"ID : {shelfTenant.TenantId}/nNavn : {shelfTenant.FirstName} {shelfTenant.LastName}/nTelefon Nummer : {shelfTenant.Phone}/nEmail : {shelfTenant.Email}/nBank Konto Detaljer {shelfTenant.GetBankAccountDetails()} ";
                    Trace.WriteLine(shelfTenantDetails);
                }
            }
        }

        // calculate comission of TotalSales and sets it to CommisionDeduction so it can be used to calculate payout 
        private void SetComissionDeduction()
        {
            CommissionDeduction = TotalSale * (Commission / 100);
        }
        // Method that loads tenant data. Needs to get filled in after implementation of database.
        private void LoadShelfTenantData()
        {
            
        }
        //Calculate the total payout after commission deduction and possible fines
        public double CalculateTotalPayout(double fine)
        {
            Fine = fine;
            return TotalSale - CommissionDeduction - Fine;
        }
        public double CalculateTotalPayout()
        {
            return TotalSale - CommissionDeduction;
        }
    }
}
