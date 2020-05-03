using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.FoodOrdering
{
    public class CancelFood : IFoodOrderCommand
    {

        private readonly Food food;
        public string OrderID;

        public CancelFood(Food food)
        {
            this.food = food;
        }
        public void ExecuteCommand()
        {
            food.CancelFood(OrderID);
        }
    }
}
