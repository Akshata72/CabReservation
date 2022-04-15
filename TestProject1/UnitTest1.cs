using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Cabreservation
{
    public class Tests
    {
        InvoiceGenerator invoiceGenerator;
        [SetUp]
        public void Setup()
        {
            invoiceGenerator = new InvoiceGenerator();
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
    }
}