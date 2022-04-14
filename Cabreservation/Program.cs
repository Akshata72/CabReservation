using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Cabreservation
{
    public class InvoiceGenerator
    {
        readonly int PricePerKm;
        readonly int PricePerMin;
        readonly int MinimumFare;
        public InvoiceGenerator()
        {
            this.PricePerKm = 10;
            this.PricePerMin = 1;
            this.MinimumFare = 5;
        }
        public double TotalFareForSingleRide(Ride ride)
        {
            if(ride.distance<0)
            {
                throw new CabException(CabException.ExceptionType.INVALID_DISTANCE, "Invalid distance");
            }
            if(ride.time<0)
            {
                throw new CabException(CabException.ExceptionType.INVALID_TIME, "Invalid Time");
            }
            return Math.Max(MinimumFare, ride.distance * PricePerKm + ride.time * PricePerMin);
        }
        static void Main(string[] args)
        {

        }
    }
}
