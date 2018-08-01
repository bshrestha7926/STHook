using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace HillerService.DataMigration.ServiceTradeIntegration.JSONDataContracts
{
    [DataContract]
    public class AuthenticationContract
    {
        [DataMember(Name = "data")]
        public Authentication Authentication { get; set; }
    }

    [DataContract]
    public class Authentication
    {
        [DataMember(Name = "authenticated")]
        public bool Authenticated { get; set; }
        [DataMember(Name = "eulaNeeded")]
        public bool EulaNeeded { get; set; }
        [DataMember(Name = "authToken")]
        public string AuthToken { get; set; }
    }
}
