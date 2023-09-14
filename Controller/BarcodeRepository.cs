using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReaolMarkedet.Model;

namespace ReaolMarkedet.Controller
{
    internal class BarcodeRepository
    {
        private List<Barcode> barcodes;

        public BarcodeRepository()
        {
            this.barcodes = new List<Barcode>();
        }
        public void AddBarcode(Barcode barcode)
        {
            barcodes.Add(barcode);
        }

        public Barcode GetBarcode(string barcodeInNumbers)
        {
            foreach ( Barcode barcode in barcodes)
            {
                if (barcode.BarcodeInNumbers == barcodeInNumbers)
                {
                    return barcode;
                }
            }
            return null;
        }

    }
}
