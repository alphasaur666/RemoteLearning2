using NUnit.Framework;
using DesignPatternsApp;
using System;
using System.Collections.Generic;
using System.Text;
using DesignPatternsApp.FoodCostTaxCalculator;
using DesignPatternsApp.FoodDeliveryTaxCalculator;

namespace DesignPatternsTests
{
    [TestFixture]
    class FoodDeliveryTests
    {
        [SetUp]
        public void SetUp()
        {

        }


        [Test]
        public void GetCalculatedTax_WithValidInput_ReturnsExpectedValue()
        {
            IDeliveryTaxCalculator deliveryTaxCalculator = new DeliveryTaxCalculator();
            var deliveryTax = deliveryTaxCalculator.CalculateTax(200);
            Assert.AreEqual(205, deliveryTax);

        }

        [Test]
        public void 


    }
}
