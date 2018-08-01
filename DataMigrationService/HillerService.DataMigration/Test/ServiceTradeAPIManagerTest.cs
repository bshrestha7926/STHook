using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using HillerService.DataMigration.ServiceTradeIntegration;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Net;
using System.Web.Script.Serialization;

namespace HillerService.DataMigration.Test
{
    public class ServiceTradeAPIManagerTest
    {

        public bool AddCompany(Company company)
        {
            var serializer = new JavaScriptSerializer();
            var objAsJsonString = serializer.Serialize(company) as String;      

            return true;
        }

        public bool UpdateCompany(Company company)
        {

            return true;
        }

        
    }
}
