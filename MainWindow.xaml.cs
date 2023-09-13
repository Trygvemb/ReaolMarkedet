using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;



namespace ReaolMarkedet
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Call your test methods here and write the results to the output
            TestSalePriceWithDiscount();
            TestShelfTenantTotalSale();
            TestPayoutCalculation();
        }

        private void TestSalePriceWithDiscount()
        {
            // Arrange
            var barcode = new Barcode("123456");
            barcode.SetDiscount(10.0); // 10% discount
            var sale = new Sale(barcode, 100.0);

            // Act
            double priceOfSale = sale.PriceOfSale;

            // Assert
            Debug.WriteLine("TestSalePriceWithDiscount - PriceOfSale: " + priceOfSale);
        }

        private void TestShelfTenantTotalSale()
        {
            // Arrange
            var tenant = new ShelfTenant("John", "Doe", "john@example.com", "123456789");
            var barcode = new Barcode("789012");
            var sale1 = new Sale(barcode, 100.0);
            var sale2 = new Sale(barcode, 50.0);

            // Simulate adding sales to the barcode and updating the total sale for the tenant
            barcode.AddSale(sale1);
            barcode.AddSale(sale2);
            tenant.UpdateTotalSaleFromBarcode(barcode);

            // Act
            double totalSale = tenant.TotalSale;

            // Assert
            Debug.WriteLine("TestShelfTenantTotalSale - TotalSale: " + totalSale);
        }

        private void TestPayoutCalculation()
        {
            // Arrange
            var tenant = new ShelfTenant("John", "Doe", "john@example.com", "123456789");
            tenant.SetBankAccountDetails("1234-12345678"); // sets bank details
            var barcode = new Barcode("789012");
            var sale1 = new Sale(barcode, 100.0);
            var sale2 = new Sale(barcode, 50.0);

            // Simulate adding sales to the barcode and updating the total sale for the tenant
            barcode.AddSale(sale1);
            barcode.AddSale(sale2);
            tenant.UpdateTotalSaleFromBarcode(barcode);

            // Create a Payout instance and set the commission and fine
            var payout = new Payout(tenant, barcode);
            payout.Commission = 15; // 15% commission rate
            payout.Fine = 10.0;

            // Act
            double totalPayout = payout.CalculateTotalPayout();

            // Assert
            // Calculate the expected total payout manually based on the formula
            double expectedTotalPayout = tenant.TotalSale - (tenant.TotalSale * (payout.Commission / 100)) - payout.Fine;
            Debug.WriteLine("TestPayoutCalculation - TotalPayout: " + totalPayout);
            Debug.WriteLine("ExpectedTotalPayout: " + expectedTotalPayout);
            
        }
    }
}
