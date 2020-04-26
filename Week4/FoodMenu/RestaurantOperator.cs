using DesignPatternsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.FoodMenu
{
    public class RestaurantOperator
    {
        private readonly string RestaurantID;
        FoodMenu foodMenu;

        public RestaurantOperator(string RestaurantID)
        {
            this.RestaurantID = RestaurantID;
        }

        public List<FoodMenuModel> PrintFoodMenu()
        {
            foodMenu = new FoodMenu(RestaurantID);
            IIterator restaurantFoodMenu = foodMenu.CreateFoodMenuIterator();
            return PrintFoodMenu(restaurantFoodMenu);
        }

        public List<FoodMenuModel> PrintFoodMenu(IIterator iterator)
        {
            Console.WriteLine("Food Menu");
            Console.WriteLine("*********************************");

            List<FoodMenuModel> foodMenu = new List<FoodMenuModel>();

            while (iterator.HasNext())
            {
                FoodMenuModel foodMenuItem = (FoodMenuModel)iterator.Next();
                foodMenu.Add(foodMenuItem);
                Console.WriteLine("*********************************");
                Console.WriteLine($"Food ID : {foodMenuItem.FoodID}");
                Console.WriteLine($"Food Name : {foodMenuItem.FoodName}");
                Console.WriteLine($"Cuisine : {foodMenuItem.Cuisine}");
                Console.WriteLine($"Price : {foodMenuItem.Price}");
                Console.WriteLine($"Rating : {foodMenuItem.Rating}");

            }

            return foodMenu;
        }
    }
}
