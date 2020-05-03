using DesignPatternsApp.Models;
using DesignPatternsApp.Tracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DesignPatternsApp.FoodDeliveryDrivers
{
    class OrderTrackingDriver
    {
        public void OrderTrackingByUser(string restaurantId, string orderId, UserModel user, char cancel)
        {
            if (cancel != 'y')
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine("Food Delivery Status");
                Console.WriteLine("---------------------");

                Restaurant restaurant = new Restaurant(restaurantId, orderId, "Order Received!");
                restaurant.Attach(new Customers(user));
                Thread.Sleep(1000);
                restaurant.DeliveryStatus = "Dispatched..";
                Thread.Sleep(1000);
                restaurant.DeliveryStatus = "On the way..";
                Thread.Sleep(1000);
                restaurant.DeliveryStatus = "Near to your home..";
                restaurant.DeliveryStatus = "Delivered!";
            }
        }
    }
}
