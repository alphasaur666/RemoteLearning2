using DesignPatternsApp.FoodOrdering;
using DesignPatternsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.FoodDeliveryDrivers
{
    public class MealOrderDriver
    {
        public char MealOrderByUser(List<FoodMenuModel> selectedMealItems , double totalCost, string RestaurantID , out string OrderID , out UserModel user)
        {
            Console.WriteLine(string.Empty);
            Console.WriteLine("Do you want to place your order(y/n)...?");
            var wantsOrder = Console.ReadKey().KeyChar;
            Console.WriteLine(string.Empty);

            OrderID = string.Empty;
            user = new UserModel();

            if (wantsOrder == 'y')
            {
                Console.WriteLine("_________________________");
                Food food = new Food();
                OrderFood orderFood = new OrderFood(food);
                orderFood.FoodItems = selectedMealItems;
                orderFood.User = user.GetUser();
                orderFood.User.Amount = totalCost;
                orderFood.RestaurantID = RestaurantID;
                user = orderFood.User;
                Customer customer = new Customer();
                customer.TakeOrder(orderFood);
                customer.PlaceOrders();
                OrderID = orderFood.OrderID;
                Console.WriteLine(string.Empty);
            }
            else
            {
                if (wantsOrder == 'n')
                {
                    Console.WriteLine("Order declined.");
                    
                }
                throw new Exception("Something is wrong!!!");
            }

            //Order Cancellation.
            char cancel = 'n';
            if (!string.IsNullOrEmpty(OrderID))
            {
                Console.WriteLine("Do you want to cancel your order(y/n)...?");
                cancel = Console.ReadKey().KeyChar;
                Console.WriteLine(string.Empty);

                if (cancel == 'y')
                {
                    Console.WriteLine(String.Empty);
                    Food food = new Food();
                    CancelFood cancelOrder = new CancelFood(food);
                    cancelOrder.OrderID = OrderID;
                    Customer customer = new Customer();
                    customer.TakeOrder(cancelOrder);
                    customer.PlaceOrders();
                }
            }

            return cancel;

        }
    }
}
