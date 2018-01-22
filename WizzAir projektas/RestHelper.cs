using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace WizzAir_projektas
{
    public class RestHelper
    {
        private static string baseUrl = ConfigurationManager.AppSettings["BaseUrl"];

        public static T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient
            {
                BaseUrl = new Uri(baseUrl),
                UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10.6; rv:10.0) Gecko/20100101 Firefox/10.0"
            };
           
            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error occured. Check exception log";
                var exception = new ApplicationException(message, response.ErrorException);
                throw exception;
            }
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public static RestRequest GetFares(string resource, object body)
        {
            var request = new RestRequest
            {
                //JsonSerializer Serializer = new Newtonsoft.Json.JsonSerializer
                RequestFormat = DataFormat.Json,
                Resource = resource,
                Method = Method.POST,
        };
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddParameter("application/json", JsonConvert.SerializeObject(body), ParameterType.RequestBody);
            return request;
        }

        public static SearchInfo timeTableBody = new SearchInfo
        {
            adultCount = 1,
            childCount = 0,
            infantCount = 0,
            priceType = "regular",
            flightList = new List<FlightList>
            {
                new FlightList{arrivalStation="BVA", departureStation="VNO", from = DateTime.Parse("2018-02-01"), to = DateTime.Parse("2018-02-28"), date = null} }
        };

        public static SearchInfo fareChartBody = new SearchInfo
        {
            wdc = false,
            adultCount = 1,
            childCount = 0,
            dayInterval = 3,
            isRescueFare = false,
            flightList = new List<FlightList>
                { new FlightList {arrivalStation = "BVA", date = DateTime.Parse("2018-02-04"), departureStation = "VNO" } }
        };
    }
}
