using DesignPatternsApp.FoodOrdering;
using DesignPatternsApp.Models;
using DesignPatternsApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.FoodMenu
{
    public class FoodMenu : IFoodMenu
    {
        private readonly string RestaurantID;



        public FoodMenu(string RestaurantID)
        {
            this.RestaurantID = RestaurantID;
        }

        public List<FoodMenuModel> GetFoodMenuItems()
        {
            FoodMenuService foodMenuService = new FoodMenuService(RestaurantID);
            var foodMenuItems = foodMenuService.getFoodMenu(RestaurantID);
            return foodMenuItems;
        }

        public IIterator CreateFoodMenuIterator()
        {
            var foodMenuItems = GetFoodMenuItems();
            return new RestaurantFoodMenuIterator(foodMenuItems);
        }
    }
}
