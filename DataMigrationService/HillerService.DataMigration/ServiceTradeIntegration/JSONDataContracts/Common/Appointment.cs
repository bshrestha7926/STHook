using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace HillerService.DataMigration.ServiceTradeIntegration.JSONDataContracts
{
    [DataContract]
    public class AppointmentDataContractMultiple
    {
        [DataMember(Name = "data")]
        public AppointmentDataContract AppointmentsMultiple { get; set; }

    }

    [DataContract]
    public class AppointmentDataContract
    {
        [DataMember(Name = "appointments")]
        public Appointment[] Appointments { get; set; }

    }

    [DataContract]
    public class Appointment
    {
        [DataMember(Name = "id")]
        public int AppId { get; set; }
        [DataMember(Name = "uri")]
        public string Uri { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "techs")]
        public User[] Techs { get; set; }


    }
}
