using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MvcUI.Utility.Api
{
    public class HttpService
    {
        static Uri url = new Uri("https://localhost:44329/api");

       

        public static string Get(string controllerName, string requestUri)
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            string result = string.Empty;
            using (var client = new HttpClient(httpHandler))
            {
                client.BaseAddress = new Uri(url.AbsoluteUri + "/" + controllerName + "/"); 
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(requestUri).Result;
                if (response.IsSuccessStatusCode)
                {
                    //if (response.Content.Headers.ContentLength <= 4)
                    //    result = string.Empty;
                    //else
                    //    result = response.Content.ReadAsAsync<object>().Result.ToString();
                }
            }
            return result;
        }

        public static string Get(string controllerName, string requestUri, int id)
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

            string result = string.Empty;
            using (var client = new HttpClient(httpHandler))
            {
                client.BaseAddress = new Uri(url.AbsoluteUri + "/" + controllerName + "/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync(requestUri + "/" + id.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    //if (response.Content.Headers.ContentLength <= 4)
                    //    result = string.Empty;
                    //else
                    //    result = response.Content.ReadAsAsync<object>().Result.ToString();
                }
            }
            return result;
        }



    }
}