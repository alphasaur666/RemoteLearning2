using DesignPatternsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.Tracking
{
    public class Customers : ICustomer
    {
        private UserModel userModel;
        public Restaurant Restaurant { get; set; }

        public Customers(UserModel userModel)
        {
            this.userModel = userModel;
        }

        public void Update(FoodDelivery foodDelivery)
        {
            Console.WriteLine($"Notified Restaurant {foodDelivery.RestaurantID} of order {foodDelivery.OrderID} at date time {foodDelivery.DeliveryTime} food delivery status: {foodDelivery.DeliveryStatus}");
        }
    }
}
