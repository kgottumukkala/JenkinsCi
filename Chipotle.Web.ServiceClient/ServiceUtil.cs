using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization.Json;

namespace Chipotle.Web.ServiceClient
{
    public class ServiceUtil
    {


        static WebClient client = default( WebClient );
        static HttpResponseMessage response = default( HttpResponseMessage );

        internal static Stream GetEntities (string serviceUrl, string entityId = "")
        {

            HttpClientSetup();
            Stream responseStream = default( Stream );
            try
            {
                if ( !string.IsNullOrEmpty( entityId ) )
                {
                    serviceUrl = serviceUrl + "/" + entityId;
                }
                byte[] responseData = client.DownloadData( serviceUrl );
                responseStream = new MemoryStream( responseData );
            }
            catch
            {
                throw;
            }
            return responseStream;
        }

        internal static string PostEntity(string serviceUrl, string inputData = "", string method = "POST", string entityId = "")
        {
            string responseMessage = string.Empty;
            HttpClientSetup();
            try
            {
                if(!string.IsNullOrEmpty(entityId))
                {
                    serviceUrl = serviceUrl + "/" + entityId;
                }
                responseMessage = client.UploadString( serviceUrl, method, inputData );
            }
            catch(Exception ex)
            {
                responseMessage = ex.Message;
                throw;
            }
            return responseMessage;
            
            
        }

        
        


        //protected static HttpResponseMessage PostEntity<T>(string serviceUrl, T t)
        //{
        //    HttpClientSetup();
        //    try
        //    {
        //        string jsonObject = JsonConvert.SerializeObject(t);
        //        HttpContent content = new StringContent( jsonObject, Encoding.UTF8 );
        //        response = client.PostAsync( serviceUrl, content ).Result;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return response;
        //}

        //protected static HttpResponseMessage PutEntity<T>(string serviceUrl, T t)
        //{
        //    HttpClientSetup();
        //    try
        //    {
        //        string jsonObject = JsonConvert.SerializeObject( t );
        //        HttpContent content = new StringContent( jsonObject, Encoding.UTF8 );
        //        response = client.PutAsync( serviceUrl, content ).Result;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return response;    
        //}

        //protected static HttpResponseMessage DeleteEntity<T> ( string serviceUrl )
        //{
        //    HttpClientSetup();
        //    try
        //    {                   
        //        response = client.DeleteAsync( serviceUrl ).Result;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    return response;
        //}

        private static void HttpClientSetup()
        {
            client = new WebClient();
            client.BaseAddress = Properties.Settings.Default.BaseJsonServiceUrl;
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
        }



        
    }
}
