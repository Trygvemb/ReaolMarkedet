using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaolMarkedet
{
    internal class ShelfTenant
    {
        private string tenantId;
        private string firstName;
        private string lastName;
        private string email;
        private string accountDetails;
        private string phone; // Change to string
        private double totalSale = 0;
        private static int count = 0;

        public string TenantId
        {
            get { return tenantId; }
            set { tenantId = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string AccountDetails
        {
            get { return accountDetails; }
            set { accountDetails = value; }
        }
        public string Phone // Change to string
        {
            get { return phone; }
            set { phone = value; }
        }
        public double TotalSale
        {
            get { return totalSale; }
            set { totalSale = value; }
        }

        public ShelfTenant(string firstName, string lastName, string email, string phone) // Change parameter type to string
        {
            count++;
            TenantId = $"T{count}";
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phone = phone;
        }


    }
}