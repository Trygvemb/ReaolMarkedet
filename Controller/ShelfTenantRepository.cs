using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReaolMarkedet.Model;

namespace ReaolMarkedet.Controller
{
    internal class ShelfTenantRepository
    {
        private List<ShelfTenant> shelfTenants;

        public ShelfTenantRepository()
        {
            this.shelfTenants = new List<ShelfTenant>();
        }

        public void AddShelTenant(ShelfTenant shelfTenant)
        {
            shelfTenants.Add(shelfTenant);
        }

        public ShelfTenant GetShelfTenant(string tenantID)
        {
            foreach (ShelfTenant shelfTenant in shelfTenants)
            {
                if (shelfTenant.TenantId == tenantID)
                {
                    return shelfTenant;
                }
            }
            return null;
        }

        public void RemoveShelfTenant(string tenantID)
        {
            foreach (ShelfTenant shelfTenant in shelfTenants)
            {
                if (shelfTenant.TenantId == tenantID)
                {
                    shelfTenants.Remove(shelfTenant);
                }
            }
        }
    }
}
