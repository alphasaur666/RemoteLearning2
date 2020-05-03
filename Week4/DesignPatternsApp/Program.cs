using DesignPatternsApp.FoodDeliveryDrivers;
using DesignPatternsApp.Models;
using System;

namespace DesignPatternsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RestaurantSearchDriver restaurantSearchDriver = new RestaurantSearchDriver();
            var RestaurantID = restaurantSearchDriver.RestaurantSearch();

            MealMenuIteratorDriver mealMenuIteratorDriver = new MealMenuIteratorDriver();
            var foodMenu = mealMenuIteratorDriver.PrintMealMenu(RestaurantID);

            MealSelectorDriver mealSelectorDriver = new MealSelectorDriver();
            var selectedMealItems = mealSelectorDriver.MealSelectionbyUser(foodMenu);

            MealBuilderDriver mealBuilderDriver = new MealBuilderDriver();
            var totalCost = mealBuilderDriver.BuildMealForUser(selectedMealItems);


            string orderID = String.Empty;
            UserModel user = null;
            MealOrderDriver mealOrderDriver = new MealOrderDriver();
            var cancel = mealOrderDriver.MealOrderByUser(selectedMealItems, totalCost, RestaurantID, out orderID, out user);

            OrderTrackingDriver orderTrackingDriver = new OrderTrackingDriver();
            orderTrackingDriver.OrderTrackingByUser(RestaurantID, orderID, user, cancel);


        }
    }
}
