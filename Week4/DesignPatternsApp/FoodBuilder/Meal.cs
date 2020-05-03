using DesignPatternsApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DesignPatternsApp.FoodBuilders
{
    public class Meal
    {
        private readonly List<FoodMenuModel> foodItems = new List<FoodMenuModel>();

        public void AddFoodItem(List<FoodMenuModel> items)
        {
            foodItems.AddRange(items);
        }

        public double ComputePrice()
        {
            double price = 0;

            foreach(var item in foodItems)
            {
                price = price + item.Price;
            }

            return price;
        }

        public void ShowItems()
        {
            foreach(var item in foodItems)
            {
                Console.WriteLine($"Food Name: {item.FoodName}");
                Console.WriteLine($"Food Price: {item.Price}");
                Console.WriteLine($"Food Rating: {item.Rating}");
                Console.WriteLine("--------------------------------------");
            }
        }
    }
}
