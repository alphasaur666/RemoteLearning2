using DesignPatternsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.Services
{
    public class FoodMenuService
    {
        public FoodMenuService(string restaurantID)
        {

        }

        public List<FoodMenuModel> getFoodMenu(string RestaurantID)
        {
            List<FoodMenuModel> foodMenu = new List<FoodMenuModel>();
            foodMenu.Add(new FoodMenuModel { RestaurantID = RestaurantID, FoodID = "1", Cuisine = "German", FoodName = "Cremwurst with fries", Rating = 5, Price = 300 });
            foodMenu.Add(new FoodMenuModel { RestaurantID = RestaurantID, FoodID = "2", Cuisine = "English", FoodName = "Fish and chips", Rating = 5, Price = 320 });
            foodMenu.Add(new FoodMenuModel { RestaurantID = RestaurantID, FoodID = "3", Cuisine = "Italian", FoodName = "Pizza Carnivore", Rating = 5, Price = 350 });
            foodMenu.Add(new FoodMenuModel { RestaurantID = RestaurantID, FoodID = "4", Cuisine = "French", FoodName = "Omlette du fromage", Rating = 5, Price = 200 });
            foodMenu.Add(new FoodMenuModel { RestaurantID = RestaurantID, FoodID = "5", Cuisine = "Romanian", FoodName = "Pork Steak with vegetables", Rating = 5, Price = 400 });
            
            return foodMenu;
        }
    }
}
