using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaolMarkedet
{
    internal class ShelfTenant
    {
        public string TenantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public double TotalSale { get; private set; }
        private string BankAccountDetails { get; set; }
        private static int count = 0;
        
        // constructor for ShelfTenant that takes all parameters
        public ShelfTenant(string firstName, string lastName, string email, string phone, string bankAccountDetails)
        {
            count++;
            TenantId = $"T{count}";
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            BankAccountDetails = bankAccountDetails;
            TotalSale = 0;
        }
        // overload for constructor that dosnt take bankaccountdeails
        public ShelfTenant(string firstName, string lastName, string email, string phone)
        {
            count++;
            TenantId = $"T{count}";
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            TotalSale = 0;
        }
        // retreive BankAccountDetails can implement decryption later on
        public string GetBankAccountDetails()
        {
            return BankAccountDetails;
        }
        // sets BankAccountDetails can implement encryption later on 
        public void SetBankAccountDetails(string bankAccountDetails)
        {
            BankAccountDetails = bankAccountDetails;
        }
        // Setter for TotalSale retrieved from Barcode
        public void UpdateTotalSaleFromBarcode(Barcode barcode)
        {
            TotalSale = barcode.GetTotalSalesAmount();
        }
    }
}