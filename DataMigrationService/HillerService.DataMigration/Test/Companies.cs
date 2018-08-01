using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HillerService.DataMigration.Test
{
    public class Company
    {
        public HillerService.DataMigration.ServiceTradeIntegration.Company NewCompany
        {
            get {
                    HillerService.DataMigration.ServiceTradeIntegration.Company ret = new HillerService.DataMigration.ServiceTradeIntegration.Company();
                    ret.scan8 = "TST7";
                    ret.name = "Test7Company";
                    ret.addressStreet = "Mickey St";
                    ret.addressCity = "Tampa";
                    ret.addressState = "FL";
                    ret.addressPostalCode = "11111";
                    ret.customer = true;
                    ret.vendor = false;
                    ret.primeContractor = false;
                    ret.phoneNumber = "(111)021-0000";
                    ret.status = "active";
                    return ret;
                }
        }
    }
}
