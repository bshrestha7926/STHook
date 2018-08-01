using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Net;
using System.Web.Script.Serialization;
using System.IO;
using System.Configuration;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Linq;
using HillerService.DataMigration.ServiceTradeIntegration.JSONDataContracts;
using HillerService.DataMigration.Entity;
using Newtonsoft.Json;

namespace HillerService.DataMigration.ServiceTradeIntegration
{
    /*
     * Use this when sending data to Service Trade
     * 
     */
    public struct Company
    {
        [ScriptIgnore]
        public string scan8;
        public string name;
        public string addressStreet;
        public string addressCity;
        public string addressState;
        public string addressPostalCode;
        public bool customer;
        public bool vendor;
        public bool primeContractor;
        public string phoneNumber;
        public string status;
        [ScriptIgnore]
        public char type;
    }

    public struct Location
    {
        [ScriptIgnore]
        public string slan8;
        [ScriptIgnore]
        public string slpan8;
        public string name;
        public string addressStreet;
        public string addressCity;
        public string addressState;
        public string addressPostalCode;
        public string companyId;
        public int[] officeIds;
        public string phoneNumber;
        [ScriptIgnore] //TODO: remove this later
        public int? primaryContactId;
        [ScriptIgnore]
        public char type;
    }

    public struct Contact
    {
        public int companyId;
        public int? locationId;
        public string status;
        public string type;
        public string firstName;
        public string lastName;
        public string phone;
        public string cell;
        public string email;
    }

    public struct Invoice
    {
        [ScriptIgnore]
        public string SIID;
        public string type;
        public string status;
        public int? jobId;
        public string invoiceNumber;
        public Int32 transactionDate;
        public int? assignedUserId;

    }

    public class ServiceTradeAPIManager : IApiManager
    {
        private string uriStr;
        private string credentials;
        private Authentication authorization;
        //private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        Logs.SThookLog st = new Logs.SThookLog();

        public ServiceTradeAPIManager()
        {
            var hook = st.ServiceTradeSettings();

            if (st.CheckOperationMode() == true) //Production Settings
            {
                uriStr = hook.ServiceTradeURI; 
                credentials = string.Format("{{\"username\":\"{0}\", \"password\": \"{1}\"}}", hook.ServiceTradeUserName, hook.ServiceTradePassword);
            }
            else //Test Settings
            {
                uriStr = hook.ServiceTradeURITest;
                credentials = string.Format("{{\"username\":\"{0}\", \"password\": \"{1}\"}}", hook.ServiceTradeUserNameTest, hook.ServiceTradePasswordTest);
            }

            //AppSettingsSection hillerSettings = config.GetSection("HillerService.Credentials") as AppSettingsSection;
            //uriStr =  hillerSettings.Settings["ServiceTradeUri"].Value;          
           

            //credentials = string.Format("{{\"username\":\"{0}\", \"password\": \"{1}\"}}", hillerSettings.Settings["UserName"].Value, hillerSettings.Settings["Password"].Value);

           

            GetAuthorization();
        }

        private HttpWebRequest Request(Uri resourceUri)
        {
            if ( credentials == null)
                    return null;

            HttpWebRequest req = null;

            return req as HttpWebRequest;
        }


        //Service Trade Authorization
        private void GetAuthorization()
        {

            var client = new RestClient();
            client.EndPoint = @uriStr+"auth";
            client.Method = HttpVerb.POST;
            client.ContentType = "application/json";
            client.PostData = credentials;

            //Get Authorization Log
            st.insertLog(client.EndPoint + client.Method + client.PostData.ToString(), "Service Trade Authorization", "NA", HillerServiceDataMigrator.LogId);

            using (var response = client.MakeRequest())
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(AuthenticationContract));
                object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());                
                AuthenticationContract jsonResponse = objResponse as AuthenticationContract;
                authorization = jsonResponse.Authentication;
                response.Close();
            }            
        }

        #region Company
        
        //Add Company on Service Trade
        public bool AddCompany(Company JDE)
        { 
            bool success = false;

            int? exists = FindCompanyServiceTradeId(JDE.scan8);

            if (exists != null)
            {
                //log.Error("Company Already Exists.");
                success = true; 
            }               
                            
            
            var serializer = new JavaScriptSerializer();
            var objAsJsonString = serializer.Serialize(JDE) as String;

            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;

            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @uriStr + "company";
            client.Method = HttpVerb.POST;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings; 
            client.PostData = objAsJsonString;
            

            using (var response = client.MakeRequest())
            {
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    try
                    {
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(CompanyContract));
                        object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                        CompanyContract jsonResponse = objResponse as CompanyContract;

                        //Assign the JDE id to the returned Company for further processing
                        if (jsonResponse.IFSTCOMP.External.JdeId == string.Empty || jsonResponse.IFSTCOMP.External.JdeId == null)
                        {
                            jsonResponse.IFSTCOMP.External = new ExternalId() { JdeId = JDE.scan8 };
                        }
                        success = CreateCompanyExternalId(jsonResponse.IFSTCOMP);
                    }
                    catch (Exception ex)
                    {
                        //log.Error(response.StatusCode.ToString());
                    }
                    response.Close();
                }               
            }

            return success;
        }


        //Add External ID for Company in Service Trade
        private bool CreateCompanyExternalId(FSTCOMP JDE)
        {

            bool success = false;
            string externalAddr = string.Format(uriStr + "externalid/company/{0}/jde", JDE.CompanyId);

            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;

            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @externalAddr;
            client.Method = HttpVerb.POST;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings; 
            client.PostData = string.Format("{{\"value\":\"{0}\"}}", JDE.External.JdeId);

            using (var response = client.MakeRequest())
            {
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    success = true;
                    response.Close();
                }
                
            }

            return success;
        }      

       //Send Update Company Data in Service Trade
        public bool UpdateCompany(Company JDE)
        {
            bool success = false;
            var serializer = new JavaScriptSerializer();
            var objAsJsonString = serializer.Serialize(JDE) as String;

            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;

            int? company_id = FindCompanyServiceTradeId(JDE.scan8);


            if (company_id != null)
            {
                success = SendCompanyUpdate((int)company_id, objAsJsonString);
            }
            return success;
        }



        private bool SendCompanyUpdate(int stid, string data)
        {
            bool success = false;

            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;

            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @uriStr + string.Format("company/{0}",stid);
            client.Method = HttpVerb.POST;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings;
            client.PostData = data;

            using (var response = client.MakeRequest())
            {
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    success = true;
                }
                else
                {
                    if (response == null)
                    {
                        //log.Error("Unknown error");                        
                    }
                    else
                    {
                        //log.Error(response.StatusDescription);
                    }
                }
                
            }

            return success;
        }

        //Get company id using external id
        private int? FindCompanyServiceTradeId(string jdeId)
        {
            int? returnVal = null;

            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;

            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @uriStr + "externalid/company/jde/" + jdeId;
            client.Method = HttpVerb.GET;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings;

            using (var response = client.MakeRequest())
            {
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    try
                    {
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(CompanyContract));
                        object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                        CompanyContract jsonResponse = objResponse as CompanyContract;
                        returnVal = jsonResponse.IFSTCOMP.CompanyId;
                    }
                    catch (Exception ex)
                    {
                        //log.Error(response.StatusCode.ToString());
                    }
                    finally
                    {
                        response.Close();
                    }
                    
                }                
            }

            return returnVal;
        }

        //Get assigned jde external id for the Company
        public string GetCompanyExternalId(int companyid)
        {
            string externalid = string.Empty;

            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;
            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @uriStr + string.Format("externalid/company/{0}/jde", companyid);
            client.Method = HttpVerb.GET;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings;


            using (var response = client.MakeRequest())
            {
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                   
                    try
                    {

                        string j = new StreamReader(response.GetResponseStream()).ReadToEnd();

                        JObject json = JObject.Parse(j);


                       //JObject json = JObject.Parse(new StreamReader(response.GetResponseStream()).ReadToEnd());
                     //   response result = JObject.Parse(new StreamReader(response.GetResponseStream()).ReadToEnd());
                        
                        externalid = json["data"]["value"].Value<string>();
                    }
                    catch (Exception e)
                    {
                        st.insertLog("No company external id found for " + companyid.ToString(), "Exception Error", companyid.ToString(), HillerServiceDataMigrator.LogId);
                    }
                    response.Close();
                }                
            }

            return externalid;
        }
        #endregion

        #region Location

        //Add new location in Service Trade
        public bool AddLocation(Location JDE)
        {
            bool success = false;

            //Find the company in service trade
            int? company_id = FindCompanyServiceTradeId(JDE.slpan8);
            FSTLOCN existing_loc = FindLocationServiceTradeId(JDE.slan8);


            if (company_id != null && existing_loc == null)
            {
                JDE.companyId = company_id.ToString();

                var serializer = new JavaScriptSerializer();
                var objAsJsonString = serializer.Serialize(JDE) as String;

                //Set cookie
                string c_settings = "PHPSESSID=" + authorization.AuthToken;

                //Create request and send to ServiceTrade           
                var client = new RestClient();
                client.EndPoint = @uriStr + "location";
                client.Method = HttpVerb.POST;
                client.ContentType = "application/json";
                client.SessionCookie = c_settings;
                client.PostData = objAsJsonString;


                using (var response = client.MakeRequest())
                {
                    if (response != null && response.StatusCode == HttpStatusCode.OK)
                    {
                        try
                        {
                            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(LocationDataContract));
                            object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                            LocationDataContract jsonResponse = objResponse as LocationDataContract;

                            //Assign the JDE id to the returned Company for further processing
                            if (jsonResponse.FSTLOCN.External.JdeId == string.Empty)
                            {
                                jsonResponse.FSTLOCN.External = new ExternalId() { JdeId = JDE.slan8 };
                            }
                            success = CreateLocationExternalId(jsonResponse.FSTLOCN);
                        }
                        catch (Exception ex)
                        {
                         //   log.Error(ex.Message);
                        }

                        response.Close();
                    }                    
                }
            }
            else if (existing_loc != null)
            {
                success = true;
            }
            
            return success;
        }

        //Add Location External Id
        private bool CreateLocationExternalId(FSTLOCN ServiceTradeLocation)
        {
            bool success = false;
            string externalAddr = string.Format(uriStr + "externalid/location/{0}/jde", ServiceTradeLocation.LocationId);

            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;

            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @externalAddr;
            client.Method = HttpVerb.POST;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings;
            client.PostData = string.Format("{{\"value\":\"{0}\"}}", ServiceTradeLocation.External.JdeId);

            using (var response = client.MakeRequest())
            {
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    success = true;
                    response.Close();
                }                
            }

            return success;
        
        }
        
        //location Update
        public bool UpdateLocation(Location JDE)
        {
            bool success = false;
            var serializer = new JavaScriptSerializer();

            FSTLOCN existing_loc = FindLocationServiceTradeId(JDE.slan8);


            if (existing_loc != null)
            {
                JDE.companyId = existing_loc.Company.CompanyId.ToString();
                var objAsJsonString = serializer.Serialize(JDE) as String;
                success = SendLocationUpdate(existing_loc.LocationId, objAsJsonString);
            }
            return success;   
        
        }

        private bool SendLocationUpdate(int locId, string data)
        {
            bool success = false;

            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;

            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @uriStr + string.Format("location/{0}", locId);
            client.Method = HttpVerb.POST;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings;
            client.PostData = data;

            using (var response = client.MakeRequest())
            {
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    success = true;
                    response.Close();
                }                
            }

            return success;
        }

        private FSTLOCN FindLocationServiceTradeId(string jdeId)
        {
            FSTLOCN loc = null;

            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;

            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @uriStr + "externalid/location/jde/" + jdeId;
            client.Method = HttpVerb.GET;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings;

            using (var response = client.MakeRequest())
            {
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    try
                    {
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(LocationDataContract));
                        object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                        LocationDataContract jsonResponse = objResponse as LocationDataContract;
                        loc = jsonResponse.FSTLOCN;
                    }
                    catch (Exception ex)
                    {
                       // log.Error(ex.Message);
                    }
                    response.Close();
                }                
            }

            return loc;
        }


        //Get External Id For the Location
        public string GetLocationExternalId(int id)
        {
            string externalid = string.Empty;

            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;

            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @uriStr + string.Format("externalid/location/{0}/jde",id);
            client.Method = HttpVerb.GET;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings;

            using (var response = client.MakeRequest())
            {
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    string j = new StreamReader(response.GetResponseStream()).ReadToEnd();

                    JObject json = JObject.Parse(j);

                    //JObject json = JObject.Parse(new StreamReader(response.GetResponseStream()).ReadToEnd());
                    try
                    {
                        externalid = json["data"]["value"].Value<string>();
                    }
                    catch (Exception e)
                    {
                        st.insertLog("No location external id found for " + id.ToString(), "Exception Error", id.ToString(), HillerServiceDataMigrator.LogId);
                    }
                    response.Close();
                }
            }

            return externalid;
        }
        #endregion

        #region Invoice


        //Get lists of invoices from Service Trade
        public List<FSTINV> GetInvoices()
        {
            List<FSTINV> Invoices = new List<FSTINV>();

            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;

            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @uriStr + "invoice";
            client.Method = HttpVerb.GET;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings;
            
            //Request the Invoices with the Type=Inovice and Status = Sent
            using (var response = client.MakeRequest(string.Format("?status=sent&type=invoice")))
            {
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    try
                    {
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(InvoiceDataContractMultiple));
                        object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                        InvoiceDataContractMultiple jsonResponse = objResponse as InvoiceDataContractMultiple;
                        Invoices = jsonResponse.Invoices.InvoiceList;
                    }
                    catch (Exception ex)
                    {
                        st.insertLog(ex.Message, "Exception Error", "NA", HillerServiceDataMigrator.LogId);
                    }
                    finally
                    {
                        response.Close();
                    }                    
                }                
            }
            
            return Invoices;
        }



        public List<Tag> GetTags(string _invoiceId)
        {
            List<Tag> Tags =new List<Tag>();
            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;


            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @uriStr + "tag";
            client.Method = HttpVerb.GET;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings;

            //Looks for the SALESMAN Tag using the Job entity first.
            string param = string.Format("?entityId={0}&entityType=6", _invoiceId);

            using (HttpWebResponse response = client.MakeRequest(param))
            {
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    try
                    {
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(TagDataContractMultiple));
                        object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                        TagDataContractMultiple jsonResponse = objResponse as TagDataContractMultiple;
                       Tags = jsonResponse.Tags.TagsList;
                    }
                    catch (Exception ex)
                    {
                        st.insertLog(ex.Message, "Exception Error", "NA", HillerServiceDataMigrator.LogId);
                    }
                    finally
                    {
                        response.Close();
                    }
                }                
            }

            return Tags;
        }

        //Get single invoice using Service Traide Invoice ID
        public FSTINV GetInvoice(string _invoiceId)
        {
            FSTINV invoice = new FSTINV(); ;

            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;

            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @uriStr + "invoice/";
            client.Method = HttpVerb.GET;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings;

            using (var response = client.MakeRequest(_invoiceId))
            {
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    try
                    {
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(InvoiceDataContract));
                        object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                        InvoiceDataContract jsonResponse = objResponse as InvoiceDataContract;
                        invoice = jsonResponse.IFSTINV;
                        
                        //var result = JsonConvert.DeserializeObject(response.ToString());
                    }
                    catch (Exception ex)
                    {
                        st.insertLog(ex.Message, "Exception Error", _invoiceId.ToString(), HillerServiceDataMigrator.LogId);
                    }
                    finally
                    {
                        response.Close();
                    }
                }
            }

            return invoice;
        }


        //Get Sales Number
        public List<string> GetSalesNumber(FSTINV inv)
        {
            st.insertLog("Get invoice sales number tag.", "Info", inv.SIID.ToString(), HillerServiceDataMigrator.LogId);

            List<string> retVal = new List<string>();
            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;

            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @uriStr + "tag";
            client.Method = HttpVerb.GET;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings;

            //Looks for the SALESMAN Tag using the Job entity first.
            string param = string.Format("?entityId={0}&entityType=3", inv.Job.JobId);

            using (HttpWebResponse response = client.MakeRequest(param))
            {
                JObject json = JObject.Parse(new StreamReader(response.GetResponseStream()).ReadToEnd());
                var data = json["data"]["tags"].Value<JArray>().ToList<JToken>();

                if (data.Count > 0)
                {

                    var tags = new List<string>(from tag in data select tag["name"].Value<string>());

                    if (tags.Count > 0)
                    {
                        retVal = (from val in tags where val.ToLower().Contains("salesman") select val).ToList();
                    }
                }
                else
                {
                    //Change request: If SALESMAN tag doesn't exists in the JOB entity, look up using Servicing Office Location
                    retVal = GetSalesNumberByLocation(inv);
                }
            }

            //Use defaults if no SALESMAN tag exists
            if (retVal.Count == 0)
            {
                switch (inv.ServicingOffice.OfficeId)
                { 
                    case 138619:
                        retVal.Add(Constants.SALESMAN984);
                        break;
                    case 138620:
                        retVal.Add(Constants.SALESMAN209);
                        break;
                    default:
                        break;
                }
            }


            return retVal;
        
        }

        private List<string> GetSalesNumberByLocation(FSTINV inv)
        {
            List<string> retVal = new List<string>();
            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;

            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @uriStr + "tag";
            client.Method = HttpVerb.GET;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings;

            string param = string.Format("?entityId={0}&entityType=11", inv.ServicingOffice.OfficeId);

            using (HttpWebResponse response = client.MakeRequest(param))
            {
                JObject json = JObject.Parse(new StreamReader(response.GetResponseStream()).ReadToEnd());
                var data = json["data"]["tags"].Value<JArray>().ToList<JToken>();

                var tags = new List<string>(from tag in data select tag["name"].Value<string>());

                if (tags.Count > 0)
                {
                    retVal = (from val in tags where val.Contains("SALESMAN") select val).ToList();
                }

            }

            return retVal;
        }


        //Get comments for the Invoices
        public CommentsList GetInvoiceComments(FSTINV inv)
        {
            st.insertLog("Get invoice public comments.", "Info", inv.SIID.ToString(), HillerServiceDataMigrator.LogId);

            CommentsList retVal = new CommentsList();

            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;

            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @uriStr + "comment";
            client.Method = HttpVerb.GET;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings;

            string param = string.Format("?entityId={0}&entityType=6&visibility=public", inv.SIID);

            using (var response = client.MakeRequest(param))
            {
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    try
                    {
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(CommentDataContainer));
                        object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                        CommentDataContainer data = objResponse as CommentDataContainer;
                        retVal = data.CommentsList;
                    }
                    catch (Exception ex)
                    {
                        st.insertLog(ex.Message, "Exception Error", inv.SIID.ToString(), HillerServiceDataMigrator.LogId);
                    }
                    finally
                    {
                        response.Close();
                    }
                }
            }

            return retVal;
            
        }

        public Office GetServicingOffice(int locationId)
        {
            LocationDataContract jsonResponse = new LocationDataContract();

            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;

            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @uriStr + string.Format("location/{0}", locationId);
            client.Method = HttpVerb.GET;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings;

            using (var response = client.MakeRequest())
            {
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    try
                    {
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(LocationDataContract));
                        object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                        jsonResponse = objResponse as LocationDataContract;
                    }
                    catch (Exception ex)
                    {
                        st.insertLog(ex.Message, "Exception Error", locationId.ToString(), HillerServiceDataMigrator.LogId);
                    }
                    finally
                    {
                        response.Close();
                    }
                }
            }

            return jsonResponse.FSTLOCN.Offices[0] != null ? jsonResponse.FSTLOCN.Offices[0] : null;

        }


        //Update Invoice Data
        public bool UpdateInvoice(Invoice invoice)
        {
            bool success = false;

            st.insertLog("Updating invoice " + invoice.SIID, "Info", invoice.SIID.ToString(), HillerServiceDataMigrator.LogId);

            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;

            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @uriStr + string.Format("invoice/{0}", invoice.SIID);
            client.Method = HttpVerb.PUT;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings;


            //Use reflection to assign values to Invoice struct
            Type type = typeof(Invoice);
            FieldInfo[] infos = type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);

            string data = "{";

            for (int x = 0; x < infos.Length; x++)
            {
                var value = infos[x].GetValue(invoice);

                if (value != null && !infos[x].Name.Equals("SIID"))
                {
                    switch (infos[x].Name.ToLower())
                    { 
                        case "type":
                        case "status":
                        case "invoicenumber":
                            data += string.Format(@"""{0}"":""{1}"",", infos[x].Name, value);
                            break;
                        case "jobid":
                        case "transactiondate":
                            data += string.Format(@"""{0}"":{1},", infos[x].Name, value);
                            break;
                        default:
                            break;
                    }
                    //data += string.Format("{0}: {1},", @""+infos[x].Name+"", value.GetType() == typeof(string) ? @""+value+"" : value);
                }

            }
            //Make sure to remove the comma at the end of the last parameter.
            data = data.TrimEnd(',');
            data += "}";

            client.PostData = data;

            using (var response = client.MakeRequest())
            {
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    success = true;
                    response.Close();
                }                
            }

            return success;
        }


        //Change the Invoice Status to Pending Accounting
        public bool SetInvoiceToPending(string invoice)
        {
            st.insertLog(string.Format("Set invoice {0} to Pending Accounting", invoice), "Info", invoice.ToString(), HillerServiceDataMigrator.LogId);
            //if (invoice.Status.CompareTo("processed") != 0)
            //    return false;

            bool success = false;

            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;

            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @uriStr + string.Format("invoice/{0}", invoice);
            client.Method = HttpVerb.POST;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings;

           // st.insertLog("Contact Endpoint" + client.EndPoint, "Info", "NA", HillerServiceDataMigrator.LogId);

            client.PostData = string.Format(@"{{""status"":""pending_accounting""}}");

            using (var response = client.MakeRequest())
            {
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    success = true;
                    response.Close();
                }
            }

            return success;
        }

        public bool SetInvoiceToProcessed(FSTINV invoice)
        {
            if(invoice.Status.CompareTo("processed") != 0)
                return false;

            bool success = false;

            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;

            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @uriStr + string.Format("invoice/{0}", invoice.SIID);
            client.Method = HttpVerb.POST;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings;

           // st.insertLog("Contact Endpoint" + client.EndPoint, "Info", "NA", HillerServiceDataMigrator.LogId);
            
            client.PostData = string.Format(@"{{""status"":""{0}""}}", invoice.Status);

            using (var response = client.MakeRequest())
            {
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    success = true;
                    response.Close();
                }
            }

            return success;
        }

        public bool GetFPMAR(int jobNumber)
        {
            JobDataContract jsonResponse = new JobDataContract();

            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;

            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @uriStr + string.Format("job/{0}", jobNumber);
            client.Method = HttpVerb.GET;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings;

            using (var response = client.MakeRequest())
            {
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    try
                    {
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(JobDataContract));
                        object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                        jsonResponse = objResponse as JobDataContract;                        
                    }
                    catch (Exception ex)
                    {
                        st.insertLog(ex.Message, "Exception Error", jobNumber.ToString(), HillerServiceDataMigrator.LogId);
                    }
                    finally
                    {
                        response.Close();
                    }
                }
            }

            if (jsonResponse.Job != null && jsonResponse.Job.ServiceRequests.Length > 0)
            {
                for (int i = 0; i < jsonResponse.Job.ServiceRequests.Length; i++)
                {

                    //check if Service line ID is not null
                    if (jsonResponse.Job.ServiceRequests[i].ServiceLineId!=null)
                    {
                      if (CheckServiceLines(jsonResponse.Job.ServiceRequests[i].ServiceLineId))
                    {
                        return true;

                    }

                    }

                   
                }
            }

            //No FPMAR abbreviation were hit 
            return false;
        }    

        //Check Service line for FPMAR
        public bool CheckServiceLines(int? svcLineId)
        {
            ServiceLineDataContract jsonResponse = new ServiceLineDataContract();
            bool result = false;

            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;

            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @uriStr + string.Format("serviceline/{0}", svcLineId);
            client.Method = HttpVerb.GET;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings;

            using (var response = client.MakeRequest())
            {
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    try
                    {
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(ServiceLineDataContract));
                        object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                        jsonResponse = objResponse as ServiceLineDataContract;
                    }
                    catch (Exception ex)
                    {
                        st.insertLog(ex.Message, "Exception Error", "", HillerServiceDataMigrator.LogId);
                    }
                    finally
                    {
                        response.Close();
                    }
                }
            }

            if (jsonResponse.ServiceLine.Abbr.Equals("FPMAR"))
            {
                result = true;
            }

            return result;
        }

        #endregion

        #region Appointment

        //Get Technician info for the Job
        public User[] GetTechnician(int jobNumber)
        {
            User[] technician = null;
            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;

            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @uriStr + string.Format("appointment?jobNumber={0}", jobNumber);
            client.Method = HttpVerb.GET;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings;

            using (var response = client.MakeRequest())
            {
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    try
                    {
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(AppointmentDataContractMultiple));
                        object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                        AppointmentDataContractMultiple jsonResponse = objResponse as AppointmentDataContractMultiple;
                        if(jsonResponse.AppointmentsMultiple.Appointments.Length > 0)                       
                            technician = jsonResponse.AppointmentsMultiple.Appointments[0].Techs; 
                    }
                    catch (Exception ex)
                    {
                        st.insertLog(ex.Message, "Exception Error", jobNumber.ToString(), HillerServiceDataMigrator.LogId);
                    }
                    response.Close();
                }
            }

            return technician;
        }
        #endregion

        #region ServiceRequest
        
        //10.12.16 JC: Determine if a given invoice item is a recurring service
        //This function returns true if there are more than one service requests
        public bool IsRecurringService(FSTINV _invoice, Item _invItem)
        {
            FSTINV invoice = _invoice;
            List<ServiceRequest> _serviceRequests;

            if (_invItem.ServiceLine == null)
            { 
                //10.12.16 JC: Re-pull the invoice
                st.insertLog("ServiceLine is empty for " + invoice.SIID + ". Re-pull invoice", "Error", _invoice.SIID.ToString(), HillerServiceDataMigrator.LogId);
                invoice = this.GetInvoice(invoice.SIID);

                if(invoice.Items.Where(itm => itm.SIITEM == _invItem.SIITEM).First().ServiceLine == null)
                {
                    //10.12.16 JC: If we still Don't have a service line, log the error
                    st.insertLog(string.Format("Invoice {0} has item {1} that do not have a service line", invoice.SIID, _invItem.LibItem.Name), "Error", invoice.SIID.ToString(), HillerServiceDataMigrator.LogId);
                    return false;
                }
            }

            //10.12.16 JC: Get a list of service requests for the invoice location in the last 18 months and for the given item service line id
            _serviceRequests = this.GetServiceRequests(invoice.Location.LocationId, invoice.Items.Where(itm => itm.SIITEM == _invItem.SIITEM).First().ServiceLine.Id);

            //10.12.16 JC: Remove service requests that has no service recurrence and has a status of void or canceled.
            _serviceRequests = _serviceRequests.Where(x => x.ServiceRecurrence != null && ! (string.Equals(x.Status.ToLowerInvariant(), "void", StringComparison.InvariantCulture) || string.Equals(x.Status.ToLowerInvariant(), "canceled", StringComparison.InvariantCulture))).ToList();

            return _serviceRequests.Count > 0;
        }

        //This functions retrieves service request for last 18 months
        public List<ServiceRequest> GetServiceRequests(int _locationId, int _serviceLineId)
        {
            //10.12.16 JC: 
            DateTime start = DateTime.Today.AddMonths(-18);
            double unixTimestamp = (double)(start.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            //Set cookie
            string c_settings = "PHPSESSID=" + authorization.AuthToken;

            //Create request and send to ServiceTrade
            var client = new RestClient();
            client.EndPoint = @uriStr + "servicerequest/"; 
            client.Method = HttpVerb.GET;
            client.ContentType = "application/json";
            client.SessionCookie = c_settings;

            using (var response = client.MakeRequest(string.Format("?locationId={0}&windowStart={1}&serviceLineIds={2}", _locationId, unixTimestamp, _serviceLineId)))
            {
                if (response != null && response.StatusCode == HttpStatusCode.OK)
                {
                    try
                    {
                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(ServiceRequestsDataContractMultiple));
                        object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                        ServiceRequestsDataContractMultiple jsonResponse = objResponse as ServiceRequestsDataContractMultiple;
                        if (jsonResponse.ServiceRequestsList.ServiceRequests.Count > 0)
                        {
                            return jsonResponse.ServiceRequestsList.ServiceRequests as List<ServiceRequest>;
                        }
                            
                    }
                    catch (Exception ex)
                    {
                        st.insertLog(ex.Message, "Exception Error", _locationId.ToString(), HillerServiceDataMigrator.LogId);
                    }
                    response.Close();
                }
            }

            return new List<ServiceRequest>(); 
        }
        #endregion
    }
}
