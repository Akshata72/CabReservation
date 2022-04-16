using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabreservation
{
    public class RideRepository
    {
        public Dictionary<string, List<Ride>> rideRepository;
        public RideRepository()
        {
            rideRepository = new Dictionary<string, List<Ride>>();
        }
        public void AddRideRepository(string userID,Ride ride)
        {
            if(rideRepository.ContainsKey(userID))
            {
                rideRepository[userID].Add(ride);
            }
            else
            {
                rideRepository.Add(userID, new List<Ride>());
            }
        }
        public List<Ride> returnListByUserID(string userID)
        {
            if (rideRepository.ContainsKey(userID))
            {
                return rideRepository[userID];
            }
            else
                throw new CabException(CabException.ExceptionType.INVALID_USER_ID, "Invalid user ID");
        }
    }
}
