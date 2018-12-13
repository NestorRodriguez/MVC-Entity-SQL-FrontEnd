using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MVC2
{
    public static class GlobalVariables
    {
        public static HttpClient WedApiClient = new HttpClient();


        static GlobalVariables()
        {
            WedApiClient.BaseAddress = new Uri("http://localhost:50466//api/");
            WedApiClient.DefaultRequestHeaders.Clear();
            WedApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
        }

    }
}