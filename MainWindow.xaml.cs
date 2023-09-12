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

            // Call the method that contains the code
            RunIntegrationCode();
        }

        private void RunIntegrationCode()
        {
            // Arrange
            var tenant = new ShelfTenant("John", "Doe", "123456789", "john@example.com", "SensitiveAccountDetails");
            var barcode = new Barcode();
            var sale1 = new Sale(barcode.BarcodeInNumbers, 100.0);
            var sale2 = new Sale(barcode.BarcodeInNumbers, 50.0);
            var sale3 = new Sale(barcode.BarcodeInNumbers, 75.0);

            // Simulate adding sales to the barcode and updating the total sale
            barcode.AddSale(sale1);
            barcode.AddSale(sale2);
            barcode.AddSale(sale3);
            tenant.UpdateTotalSaleFromBarcode(barcode);

            // Create a Payout instance and set the commission and fine
            var payout = new Payout();
            //payout.Commission = 15; // 15% commission rate
            //payout.Fine = 10.0;

            // Act
            double totalPayout = payout.CalculateTotalPayout();

            // Assert
            // Calculate the expected total payout manually based on the formula
            double expectedTotalPayout = tenant.TotalSale - (tenant.TotalSale * (payout.Commission / 100)) - payout.Fine;

            Trace.WriteLine(tenant.FirstName);
            Trace.WriteLine(tenant.LastName);
            Trace.WriteLine(tenant.Phone);
            Trace.WriteLine(tenant.Email);
            Trace.WriteLine($"Total Payout: {totalPayout}");
            Trace.WriteLine($"Expected Total Payout: {expectedTotalPayout}");

        }
    }
}

