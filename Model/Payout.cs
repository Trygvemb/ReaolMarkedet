using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReaolMarkedet.Model;

namespace ReaolMarkedet
{
    internal class Payout
    {
        private double _commission = 15; // default commission rate of 15%
        private double _fine = 0; // default fine of 0

        public double TotalPayout { get; set; }
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
        // Constructor for Payout that takes shelfTenant and Barcode as parameter. 
        public Payout(ShelfTenant shelfTenant, Barcode barcode, double fine)
        {
            // Potential automatic payout implementation here.

            shelfTenant.UpdateTotalSaleFromBarcode(barcode);
            TotalSale = shelfTenant.TotalSale;
            CalculateTotalPayout(fine);
            string shelfTenantDetails = "";
            shelfTenantDetails = $"ID : {shelfTenant.TenantId}\nNavn : {shelfTenant.FirstName} {shelfTenant.LastName}\nTelefon Nummer : {shelfTenant.Phone}\nEmail : {shelfTenant.Email}\nBank Konto Detaljer {shelfTenant.GetBankAccountDetails()} ";
            Trace.WriteLine(shelfTenantDetails);
            Trace.WriteLine($"Til Udbetaling : {TotalPayout}kr.");
                    
        }
        public Payout(ShelfTenant shelfTenant, Barcode barcode)
        {
            // Potential automatic payout implementation here.

            shelfTenant.UpdateTotalSaleFromBarcode(barcode);
            TotalSale = shelfTenant.TotalSale;
            CalculateTotalPayout();
            string shelfTenantDetails = "";
            shelfTenantDetails = $"ID : {shelfTenant.TenantId}\nNavn : {shelfTenant.FirstName} {shelfTenant.LastName}\nTelefon Nummer : {shelfTenant.Phone}\nEmail : {shelfTenant.Email}\nBank Konto Detaljer {shelfTenant.GetBankAccountDetails()} ";
            Trace.WriteLine(shelfTenantDetails);
            Trace.WriteLine($"Til Udbetaling : {TotalPayout}kr.");

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
            SetComissionDeduction();
            Fine = fine;
           return TotalPayout = TotalSale - CommissionDeduction - Fine;
        }
        public double CalculateTotalPayout()
        {
            SetComissionDeduction();
            return TotalPayout = TotalSale - CommissionDeduction - Fine;
        }
    }
}
