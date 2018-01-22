using System;
using System.Collections.Generic;

namespace WizzAir_projektas
{
    #region query flights
    public class FlightList
    {
        public string departureStation { get; set; }
        public string arrivalStation { get; set; }
        public DateTime? date { get; set; }
        public DateTime from { get; set; }
        public DateTime to { get; set; }
    }

    public class SearchInfo
    {
        public bool wdc { get; set; }
        public List<FlightList> flightList { get; set; }
        public int dayInterval { get; set; }
        public int adultCount { get; set; }
        public int childCount { get; set; }
        public int infantCount { get; set; }
        public bool isRescueFare { get; set; }
        public string priceType { get; set; }
    }
    #endregion

    #region flight response   
    public class Price
    {
        public double amount { get; set; }
        public string currencyCode { get; set; }
    }

    public class OutboundFlight
    {
        public string departureStation { get; set; }
        public string arrivalStation { get; set; }
        public Price price { get; set; }
        public string priceType { get; set; }
        public DateTime date { get; set; }
        public DateTime departureDate { get; set; }
        public object classOfService { get; set; }
        public bool hasMacFlight { get; set; }
    }

    public class RootObject
    {
        public List<OutboundFlight> outboundFlights { get; set; }
        //public List<object> returnFlights { get; set; }
    }
    #endregion

    
}
