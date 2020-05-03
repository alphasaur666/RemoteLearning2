using DesignPatternsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.FoodOrdering
{
    public class Food
    {
        public string OrderFood(string RestaurantID, UserModel userModel)
        {
            var orderID = (RestaurantID + Guid.NewGuid().ToString().Substring(0, 15)).ToUpper();
            Console.WriteLine($"Order {orderID}");
            Console.WriteLine($"Customer Name: {userModel.FullName}");
            Console.WriteLine($"Mobile Number: {userModel.PhoneNumber}");
            Console.WriteLine($"Address:  {userModel.Adress}");
            Console.WriteLine($"Amount: {userModel.Amount}");
            Console.WriteLine($"Food ordered!");
            return orderID.ToString();
        }

        public void CancelFood(string OrderID)
        {
            Console.WriteLine($"Food order {OrderID} has been canceled!");
        }
    }
}
