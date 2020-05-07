using DesignPatternsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.Services
{
    public class RestaurantService
    {

        public RestaurantService()
        {

        }

        public List<RestaurantModel> GetRestaurants()
        {
            List<RestaurantModel> restaurants = new List<RestaurantModel>();
            restaurants.Add(new RestaurantModel { RestaurantID = "1", Name = "Razvanel's Restaurant", Address = "abc", Rating = 5 });
            restaurants.Add(new RestaurantModel { RestaurantID = "2", Name = "Gabriel's Restaurant", Address = "abc", Rating = 5 });
            restaurants.Add(new RestaurantModel { RestaurantID = "3", Name = "Stefan's Restaurant", Address = "abc", Rating = 5 });
            return restaurants;
        }
    }
}
