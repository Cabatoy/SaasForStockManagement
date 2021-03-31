using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;

namespace MvcUICore.Utility.Api
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
                client.DefaultRequestHeaders.Accept.Clear();
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


        public static string Post(string controllerName, string requestUri, object model)
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
                var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = client.PostAsync(requestUri, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    //if (response.Content.Headers.ContentLength <= 4)
                    //    result = string.Empty;
                    //else
                     result  =response.Content.ReadAsStringAsync().Result;
                    //result = response.Content.ReadAsAsync<object>().Result.ToString();
                }
                else
                {
                    result = response.Content.ReadAsStringAsync().Result;
                }
            }
            return result;
        }



    }
}