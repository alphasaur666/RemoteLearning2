using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.FoodOrdering
{
    public class Customer
    {
        readonly List<IFoodOrderCommand> orderList = new List<IFoodOrderCommand>();

        public void TakeOrder(IFoodOrderCommand order)
        {
            orderList.Add(order);
        }
        public void PlaceOrders()
        {
            foreach(var order in orderList)
            {
                order.ExecuteCommand();
            }
            orderList.Clear();
        }
    }
}
