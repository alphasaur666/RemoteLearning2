using DesignPatternsApp.FoodCostTaxCalculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.FoodDeliveryTaxCalculator
{
    public class DeliveryTaxCalculationContext
    {
        private readonly IDeliveryTaxCalculator deliveryTaxCalculator;

        public DeliveryTaxCalculationContext()
        {
        }

        public DeliveryTaxCalculationContext(IDeliveryTaxCalculator deliveryTaxCalculator)
        {
            this.deliveryTaxCalculator = deliveryTaxCalculator;
        }

        public double GetCalculatedTax(double price)
        {
            return deliveryTaxCalculator.CalculateTax(price);
        }
    }
}
