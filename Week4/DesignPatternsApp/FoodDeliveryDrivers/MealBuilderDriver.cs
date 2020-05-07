using DesignPatternsApp.FoodBuilders;
using DesignPatternsApp.FoodDeliveryTaxCalculator;
using DesignPatternsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
//Builder pattern used.
namespace DesignPatternsApp.FoodDeliveryDrivers
{
    public class MealBuilderDriver
    {
        public double BuildMealForUser(List<FoodMenuModel> selectedMealItems)
        {
            Console.WriteLine("______________________________");
            Console.WriteLine("You selected those items:");
            Console.WriteLine("______________________________");
            MealBuilder mealBuilder = new MealBuilder();
            mealBuilder.PrepareMeal(selectedMealItems);
            mealBuilder.meal.ShowItems();
            var foodCost = mealBuilder.meal.ComputePrice();

            var delivery = new DeliveryTaxCalculator();
            var taxCalculationContext = new DeliveryTaxCalculationContext(delivery);
            Console.WriteLine($"Delivery fee: {delivery.deliveryTax} dollars");
            var taxAmount = taxCalculationContext.GetCalculatedTax(foodCost);
            Console.WriteLine($"Total cost: {taxAmount}");
            return taxAmount;

        }
    }
}
