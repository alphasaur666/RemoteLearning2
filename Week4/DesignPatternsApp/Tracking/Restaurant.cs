using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.Tracking
{
    public class Restaurant : FoodDelivery
    {
        public Restaurant(string RestaurantID, string OrderID, string deliveryStatus):base(RestaurantID, OrderID, deliveryStatus)
        {

        }
    }
}
