using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MutIn
{
    public static class GlobalVariables
    {
        public static HttpClient WebApiClientContrat = new HttpClient();

        static GlobalVariables()
        {
            WebApiClientContrat.BaseAddress = new Uri("http://localhost:64810/api/");
            WebApiClientContrat.DefaultRequestHeaders.Clear();
            WebApiClientContrat.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("Application/json"));
        }


    }
}