using DesignPatternsApp.FoodMenu;
using DesignPatternsApp.FoodOrdering;
using DesignPatternsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
 // Iterator pattern used.
namespace DesignPatternsApp.FoodDeliveryDrivers
{
    public class MealMenuIteratorDriver
    {
        public List<FoodMenuModel> PrintMealMenu(string RestaurantID)
        {
            RestaurantOperator restaurantOperator = new RestaurantOperator(RestaurantID);
            var foodMenu = restaurantOperator.PrintFoodMenu();
            return foodMenu;
        }
    }
}
