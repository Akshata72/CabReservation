using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Cabreservation
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator;
        premiumInvoiceGenerator premiumInvoiceGenerator;
        RideRepository rideRepository;
        [SetUp]
        public void Setup()
        {
            invoiceGenerator = new InvoiceGenerator();
            premiumInvoiceGenerator = new premiumInvoiceGenerator();
            rideRepository = new RideRepository();
        }
        /// <summary>
        /// Total Fare For Single Ride..
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        [Test]
        [TestCase(5, 3)]
        public void GivenTimeAndDistance_CalculateFare(double distance, double time)
        {
            Ride ride = new Ride(distance, time);
            int expected = 53;
            Assert.AreEqual(expected, invoiceGenerator.TotalFareForSingleRide(ride));
        }
        /// <summary>
        /// Invalid Distance
        /// </summary>
        [Test]
        public void GivenInvaliDistance_ThrowException()
        {
            Ride ride = new Ride(-1, 1);
            CabException cabException = Assert.Throws<CabException>(() => invoiceGenerator.TotalFareForSingleRide(ride));
            Assert.AreEqual(cabException.type, CabException.ExceptionType.INVALID_DISTANCE);
        }
        /// <summary>
        /// Invalid Time
        /// </summary>
        [Test]
        public void GivenInvalidTime_ThrowException()
        {
            Ride ride = new Ride(1, -1);
            CabException cabException = Assert.Throws<CabException>(() => invoiceGenerator.TotalFareForSingleRide(ride));
            Assert.AreEqual(cabException.type, CabException.ExceptionType.INVALID_TIME);
        }
        /// <summary>
        /// Total Fare For Multiple Rides..
        /// </summary>
        [Test]
        public void GivenListOfRides_GenerateInvoice()
        {
            Ride ride1 = new Ride(3, 4);
            Ride ride2 = new Ride(2, 2);

            List<Ride> rides = new List<Ride>();
            rides.Add(ride1);
            rides.Add(ride2);

            Assert.AreEqual(56, invoiceGenerator.TotalFareForMultipleRides(rides));
            Assert.AreEqual(28, invoiceGenerator.averagePerRide);
            Assert.AreEqual(2, invoiceGenerator.numOfRides);
        }
        /// <summary>
        /// For Valid User ID
        /// </summary>
        [Test]
        public void GivenValidUserID_GenerateInvoice()
        {
            Ride ride1 = new Ride(3, 4);
            Ride ride2 = new Ride(2, 2);

            rideRepository.AddRideRepository("XYZ", ride1);
            rideRepository.AddRideRepository("XYZ", ride2);
            Assert.AreEqual(56, invoiceGenerator.TotalFareForMultipleRides(rideRepository.returnListByUserID("XYZ")));
            Assert.AreEqual(28, invoiceGenerator.averagePerRide);
            Assert.AreEqual(2, invoiceGenerator.numOfRides);
        }
        [Test]
        public void GivenInvalidUserID_GenerateInvoice()
        {
            Ride ride1 = new Ride(3, 4);
            Ride ride2 = new Ride(2, 2);

            rideRepository.AddRideRepository("XYZ", ride1);
            rideRepository.AddRideRepository("XYZ", ride2);
            CabException cabException = Assert.Throws<CabException>(() => invoiceGenerator.TotalFareForMultipleRides(rideRepository.returnListByUserID("ABC")));
            Assert.AreEqual(cabException.type, CabException.ExceptionType.INVALID_USER_ID);
        }

        /// <summary>
        /// UC4- Premium Ride
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="time"></param>
        [Test]
        [TestCase(5, 3)]
        public void GivenPremiumTimeAndDistance_CalculateFare(double distance, double time)
        {
            Ride ride = new Ride(distance, time);
            int expected = 81;
            Assert.AreEqual(expected, premiumInvoiceGenerator.TotalFareForSingleRide(ride));
        }
        /// <summary>
        /// Invalid Distance for premium
        /// </summary>
        [Test]
        public void GivenPremiumInvaliDistance_ThrowException()
        {
            Ride ride = new Ride(-5, 1);
            CabException cabException = Assert.Throws<CabException>(() => premiumInvoiceGenerator.TotalFareForSingleRide(ride));
            Assert.AreEqual(cabException.type, CabException.ExceptionType.INVALID_DISTANCE);
        }
        /// <summary>
        /// Invalid Time for premium
        /// </summary>
        [Test]
        public void GivenPremiumInvalidTime_ThrowException()
        {
            Ride ride = new Ride(1, -4);
            CabException cabException = Assert.Throws<CabException>(() => premiumInvoiceGenerator.TotalFareForSingleRide(ride));
            Assert.AreEqual(cabException.type, CabException.ExceptionType.INVALID_TIME);
        }
        /// <summary>
        /// Premium Total Fare For Multiple Rides..
        /// </summary>
        [Test]
        public void GivenPremiumListOfRides_GenerateInvoice()
        {
            Ride ride1 = new Ride(3, 4);
            Ride ride2 = new Ride(2, 2);

            List<Ride> rides = new List<Ride>();
            rides.Add(ride1);
            rides.Add(ride2);

            Assert.AreEqual(87, premiumInvoiceGenerator.TotalFareForMultipleRides(rides));
            Assert.AreEqual(43.5d, premiumInvoiceGenerator.averagePerRide);
            Assert.AreEqual(2, premiumInvoiceGenerator.numOfRides);
        }
        /// <summary>
        /// Premium For Valid User ID
        /// </summary>
        [Test]
        public void GivenPremiumValidUserID_GenerateInvoice()
        {
            Ride ride1 = new Ride(3, 4);
            Ride ride2 = new Ride(2, 2);

            rideRepository.AddRideRepository("XYZ", ride1);
            rideRepository.AddRideRepository("XYZ", ride2);
            Assert.AreEqual(87, premiumInvoiceGenerator.TotalFareForMultipleRides(rideRepository.returnListByUserID("XYZ")));
            Assert.AreEqual(43.5d, premiumInvoiceGenerator.averagePerRide);
            Assert.AreEqual(2, premiumInvoiceGenerator.numOfRides);
        }
        /// <summary>
        /// Premium Invalid UserId Generate Invoice..
        /// </summary>
        [Test]
        public void GivenPremiumInvalidUserID_GenerateInvoice()
        {
            Ride ride1 = new Ride(3, 4);
            Ride ride2 = new Ride(2, 2);

            rideRepository.AddRideRepository("XYZ", ride1);
            rideRepository.AddRideRepository("XYZ", ride2);
            CabException cabException = Assert.Throws<CabException>(() => premiumInvoiceGenerator.TotalFareForMultipleRides(rideRepository.returnListByUserID("ABC")));
            Assert.AreEqual(cabException.type, CabException.ExceptionType.INVALID_USER_ID);
        }
    }
}