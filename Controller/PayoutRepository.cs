using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReaolMarkedet.Model;

namespace ReaolMarkedet.Controller
{
    internal class PayoutRepository
    {
        private List<Payout> payouts;

        public PayoutRepository()
        {
            this.payouts = new List<Payout>();
        }

        public void AddPayout(Payout payout)
        {
            payouts.Add(payout);
        }

        //public Payout GetPayout()
    }
}
