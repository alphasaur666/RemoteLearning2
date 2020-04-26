using DesignPatternsApp.RestaurantSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DesignPatternsApp.FoodDeliveryDrivers
{
    public class RestaurantSearchDriver
    {
        public string RestaurantSearch()
        {
            InterpreterContext context = new InterpreterContext();
            RestaurantSearchClient client = new RestaurantSearchClient(context);
            Console.WriteLine("Search Restaurant by location");
            Console.WriteLine("Enter Location:");
            var location = Console.ReadLine();
            string searchSentence = string.Format("restaurant by location '{0}'", location);
            var result = client.Intercept(searchSentence);
            if (!result.Any()) Console.WriteLine("Sorry, no restaurants available in this location.");


            string restaurantID = String.Empty;

            if (result.Any())
            {
                Console.WriteLine("List of Restaurants");
                Console.WriteLine("**********************************");

                foreach (var item in result)
                {
                    Console.WriteLine(" ");
                    Console.WriteLine("{0} {1}", item.RestaurantID, item.Name);
                    Console.WriteLine("{0}", item.Address);
                    int rating = item.Rating;
                    Console.Write("Rating: ");
                    while (rating > 0)
                    {
                        Console.Write("*");
                        rating--;
                    }

                    Console.WriteLine("");
                    Console.WriteLine("_________________________________");
                }

                Console.WriteLine();
                Console.WriteLine("Please select the restaurant by ID: ");
                restaurantID = Console.ReadLine();
            }
            return restaurantID;
        }
    }
}
