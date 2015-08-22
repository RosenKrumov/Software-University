using System;
using System.Web.Script.Serialization;
using RestSharp;

namespace DistanceCalculatorRestClient
{
    public class DistanceCalculatorRestClient
    {
        static void Main()
        {
            var client = new RestClient("http://localhost:9451/api");
            var request = new RestRequest("points/distance", Method.GET);
            
            request.AddQueryParameter("startX", "10");
            request.AddQueryParameter("startY", "10");
            request.AddQueryParameter("endX", "15");
            request.AddQueryParameter("endY", "15");

            var response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
