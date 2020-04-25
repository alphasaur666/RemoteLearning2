using DesignPatternsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternsApp.FoodDeliveryDrivers
{
    public class MealSelectorDriver
    {
        public List<FoodMenuModel> MealSelectionbyUser(List<FoodMenuModel> foodMenu)
        {
            Console.WriteLine("Please select the food items");
            Console.WriteLine("_____________________________");

            List<FoodMenuModel> selectedMealItems = new List<FoodMenuModel>();
            char answer;
            do
            {
                Console.WriteLine("Enter food Id:");
                var foodId = Console.ReadLine();
                var foodItem = foodMenu.FirstOrDefault(e => e.FoodID == foodId);
                if (foodItem != null)
                {
                    Console.WriteLine("You Selected Below food Item:");
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Name: {0}", foodItem.FoodName);
                    Console.WriteLine("Price: {0} dollars", foodItem.Price);
                    Console.WriteLine("Rating: {0}", foodItem.Rating);
                    selectedMealItems.Add(foodItem);
                }
                else
                {
                    Console.WriteLine("Invalid Food ID Selected.No food item available with this ID.");
                    throw new Exception("Ooops.");

                }   

                Console.WriteLine(string.Empty);

                Console.WriteLine("Do you want to add more food items (y/n):...?");
                answer = Console.ReadKey().KeyChar;
                Console.WriteLine(string.Empty);

            } while (answer != 'n');

            return selectedMealItems;
        }

    }
}
