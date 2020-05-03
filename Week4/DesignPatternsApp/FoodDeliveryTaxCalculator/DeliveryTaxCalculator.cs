using DesignPatternsApp.FoodCostTaxCalculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.FoodDeliveryTaxCalculator
{
    public class DeliveryTaxCalculator : IDeliveryTaxCalculator
    {
        public double deliveryTax = 5;
        public double CalculateTax(double price)
        {
            double tax = price + deliveryTax;
            return tax;
        }
    }
}