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

            Barcode barcode1 = new Barcode();
            Trace.WriteLine(barcode1.BarcodeInNumbers);
            Barcode barcode2 = new Barcode();
            Trace.WriteLine(barcode2.BarcodeInNumbers);
            Barcode barcode3 = new Barcode();
            Trace.WriteLine(barcode3.BarcodeInNumbers);
        }


    }

}
