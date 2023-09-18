using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReaolMarkedet.Controller
{
    internal class Controller
    {
        private BarcodeRepository barcodeRepository;
        private ShelfTenantRepository ShelfTenantRepository;
        private PayoutRepository payoutRepository;

        public Controller()
        {
            this.barcodeRepository = new BarcodeRepository();
            this.ShelfTenantRepository = new ShelfTenantRepository();
            this.payoutRepository = new PayoutRepository();
        }


    }
}
