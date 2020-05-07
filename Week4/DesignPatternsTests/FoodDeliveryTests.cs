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
        [Test]
        public void CalculateTax_WithValidInput_ReturnsExpectedValue()
        {
            IDeliveryTaxCalculator deliveryTaxCalculator = new DeliveryTaxCalculator();
            var deliveryTax = deliveryTaxCalculator.CalculateTax(200);
            Assert.AreEqual(205, deliveryTax);

        }



        [Test]
        public void GetCalculatedTax_WithValidInput_ReturnsExpectedType()
        {
            IDeliveryTaxCalculator deliveryTaxCalculator = new DeliveryTaxCalculator();
            DeliveryTaxCalculationContext deliveryTaxContext = new DeliveryTaxCalculationContext(deliveryTaxCalculator);
            var deliveryTax = deliveryTaxContext.GetCalculatedTax(200);
            Assert.IsInstanceOf(typeof(double), deliveryTax);
        }
    }
}
