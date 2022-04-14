using NUnit.Framework;
using System;

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
        [TestCase(5,3)]
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
    }
}