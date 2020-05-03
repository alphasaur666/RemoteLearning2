using DesignPatternsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.FoodMenu
{
    class RestaurantFoodMenuIterator : IIterator
    {
        readonly List<FoodMenuModel> foodItems;
        int postion;

        public RestaurantFoodMenuIterator(List<FoodMenuModel> foodItems)
        {
            this.foodItems = foodItems;
        }

        public bool HasNext()
        {
            if(postion >= foodItems.Count || foodItems[postion] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public object Next()
        {
            FoodMenuModel menuItem = foodItems[postion];
            postion++;
            return menuItem;
        }

    }
}
