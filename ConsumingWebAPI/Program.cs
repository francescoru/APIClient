using System;
using System.Net.Http;

namespace ConsumingWebAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseUrl = "https://localhost:44372/";
            CallEndpoint(baseUrl, "api/products");
            CallEndpoint(baseUrl, "api/products/2");
            CallEndpoint(baseUrl, "api/products/categories");
            CallEndpoint(baseUrl, "api/products/productbycategory/1");
        }

        public static void CallEndpoint(string baseUrl, string endpoint)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44372/");
                var response = client.GetAsync(endpoint).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseString = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine(responseString);
                }
            }
        }
    }
}
