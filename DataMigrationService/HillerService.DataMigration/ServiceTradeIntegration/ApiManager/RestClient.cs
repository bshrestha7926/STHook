using System;
using System.IO;
using System.Net;
using System.Text;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using HillerService.DataMigration.Entity;

public enum HttpVerb
{
    GET,
    POST,
    PUT,
    DELETE
}

namespace HillerService.DataMigration.ServiceTradeIntegration
{
    public class RestClient
    {
        public string EndPoint { get; set; }
        public HttpVerb Method { get; set; }
        public string ContentType { get; set; }
        public string PostData { get; set; }
        public CredentialCache Credentials { get; set; }
        public string SessionCookie { get; set; }

        Logs.SThookLog st = new Logs.SThookLog();

        public RestClient()
        {
            EndPoint = "";
            Method = HttpVerb.GET;
            ContentType = "text/xml";
            PostData = "";
        }
        public RestClient(string endpoint)
        {
            EndPoint = endpoint;
            Method = HttpVerb.GET;
            ContentType = "text/xml";
            PostData = "";
        }
        public RestClient(string endpoint, HttpVerb method)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "text/xml";
            PostData = "";
        }

        public RestClient(string endpoint, HttpVerb method, string postData)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "text/xml";
            PostData = postData;
        }


        public RestClient(string endpoint, HttpVerb method, string postData, string cookieSettings)
        {
            EndPoint = endpoint;
            Method = method;
            ContentType = "text/xml";
            PostData = postData;
            SessionCookie = cookieSettings;

        }

        public HttpWebResponse MakeRequest()
        {
            return MakeRequest("");
        }

        public HttpWebResponse MakeRequest(string parameters)
        {
            var request = (HttpWebRequest)WebRequest.Create(EndPoint + parameters);
            HttpWebResponse response = null; 

            request.Method = Method.ToString();
            request.ContentLength = 0;
            request.ContentType = ContentType;
            request.Timeout = 60000;
            request.ServicePoint.Expect100Continue = false;

            if (SessionCookie != null)
            {
                request.Headers.Add(HttpRequestHeader.Cookie, SessionCookie);
            }

            if (!string.IsNullOrEmpty(PostData) && (Method == HttpVerb.POST || Method == HttpVerb.PUT))
            {
                var encoding = new UTF8Encoding();
                var bytes = Encoding.GetEncoding("iso-8859-1").GetBytes(PostData);
                request.ContentLength = bytes.Length;
                
                try
                {
                    using (var writeStream = request.GetRequestStream())
                    {
                        writeStream.Write(bytes, 0, bytes.Length);

                        
                    }
                }
                catch (WebException ex)
                {
                    st.insertLog("Error: " + ex.Message,"Exception Error","",HillerServiceDataMigrator.LogId);
                    //log.Error("Error: " + ex.Message, ex);
                }
            }


         //   st.insertLog("Json Data: " + PostData, "Info", "", HillerServiceDataMigrator.LogId);

            try
            {
                response = (HttpWebResponse)request.GetResponse();

             //   st.insertLog("HttpWebResponse " + response.Headers.ToString(), "Info", "", HillerServiceDataMigrator.LogId);
                //log.Debug("HttpWebResponse " + response.Headers.ToString());
              //  st.insertLog("HTTPStatusCode: " + response.StatusCode.ToString(), "Info", "", HillerServiceDataMigrator.LogId);
                //log.Debug("HTTPStatusCode: " + response.StatusCode.ToString());
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    var message = String.Format("Request failed. Received HTTP {0}", response.StatusCode);
                    ApplicationException ex = new ApplicationException(message);

                    st.insertLog(message, "Exception Error","", HillerServiceDataMigrator.LogId);

                 //   log.Error(message, ex);
                    return null;
                }     

            }
            catch (Exception ex)
            {

                st.insertLog("Error: " + ex.Message, "Exception Error", "", HillerServiceDataMigrator.LogId);
               // log.Error("Error: "+ex.Message, ex);
            }                     

            return response;            
        }

    } // class

}