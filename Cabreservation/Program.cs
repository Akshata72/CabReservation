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
        public int numOfRides;
        public double totalFare;
        public double averagePerRide;
        public InvoiceGenerator()
        {
            this.PricePerKm = 10;
            this.PricePerMin = 1;
            this.MinimumFare = 5;
        }
        public double TotalFareForMultipleRides(List<Ride> rides)
        {
            foreach (Ride ride in rides)
            {
                totalFare += TotalFareForSingleRide(ride);
                numOfRides += 1;
            }
            averagePerRide = totalFare / numOfRides;
            return totalFare;
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
