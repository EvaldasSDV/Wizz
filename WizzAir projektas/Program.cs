using System;
using System.Linq;

namespace WizzAir_projektas
{
    public class Program
    {

        static void Main(string[] args)
        {
            var responseOneDate = RestHelper.Execute<RootObject>(RestHelper.GetFares("asset/farechart", RestHelper.fareChartBody));
            var exactDateFlight = responseOneDate.outboundFlights.FindAll(x => x.date == new DateTime(2018, 02, 04));
            if (exactDateFlight.Count > 1)
            {
                var minimum = exactDateFlight.Min(x => x.price.amount);
                Console.WriteLine("Pigiausia kaina: " + minimum);
            }
            else
            {
                Console.WriteLine("Pigiausia " + exactDateFlight[0].date.ToString("yyyy-MM-dd") + 
                    " dienos kaina: " + exactDateFlight[0].price.amount + exactDateFlight[0].price.currencyCode);
            }

            var responseMonth  = RestHelper.Execute<RootObject>(RestHelper.GetFares("search/timetable", RestHelper.timeTableBody));
            var minimumPrice = responseMonth.outboundFlights.Min(x => x.price.amount);
            Console.WriteLine("Pigiausia 2018m. Vasario mėn kaina: " + minimumPrice + "EUR");
        }
    }
}
