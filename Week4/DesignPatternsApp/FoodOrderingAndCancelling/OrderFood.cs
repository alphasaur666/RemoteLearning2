using DesignPatternsApp.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DesignPatternsApp.FoodOrdering
{
    public class OrderFood : IFoodOrderCommand
    {
        private readonly Food food;
        public List<FoodMenuModel> FoodItems;
        public UserModel User;
        public string OrderID;
        public string RestaurantID;

        public OrderFood(Food food)
        {
            this.food = food;
        }

        public void ExecuteCommand()
        {
            OrderID = food.OrderFood(RestaurantID, User);
        }


    }
}
