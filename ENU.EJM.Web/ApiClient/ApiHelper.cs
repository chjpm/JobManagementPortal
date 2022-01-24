using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using JetBrains.Annotations;
using System.Configuration;

namespace ENU.EJM.Web.ApiClient
{
    public class ApiHelper
    {
        private static string _apiUri = ConfigurationManager.AppSettings["ApiUri"].ToString();
        private static string _apiHelpUri = ConfigurationManager.AppSettings["ApiHelpUri"].ToString();
        public static HttpClient Client { get; set; }

        public static void InitializeClient()
        {
            Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


        }
    }
}