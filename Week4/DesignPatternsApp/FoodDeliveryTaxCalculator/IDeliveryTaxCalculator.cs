using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.FoodCostTaxCalculator
{
    public interface IDeliveryTaxCalculator
    {
        double CalculateTax(double price);
    }
}
