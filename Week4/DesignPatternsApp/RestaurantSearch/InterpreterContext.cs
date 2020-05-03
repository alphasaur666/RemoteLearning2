using DesignPatternsApp.Models;
using DesignPatternsApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.RestaurantSearch
{
    public class InterpreterContext
    {
        private readonly RestaurantService restaurantService;

        public InterpreterContext()
        {
            restaurantService = new RestaurantService();
        }

        public List<RestaurantModel> GetAllRestaurants()
        {
            return restaurantService.GetRestaurants();
        }

    }
}
