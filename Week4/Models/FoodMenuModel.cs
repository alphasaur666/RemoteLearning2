using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.Models
{
    public class FoodMenuModel
    {
        private string restaurantID;
        public string RestaurantID
        {
            get { return restaurantID; }
            set { restaurantID = value; }
        }
        private string foodID;
        public string FoodID
        {
            get { return foodID; }
            set { foodID = value; }
        }
        private string foodName;
        public string FoodName
        {
            get { return foodName; }
            set { foodName = value; }
        }
        private string cuisine;
        public string Cuisine
        {
            get { return cuisine; }
            set { cuisine = value; }
        }
        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        private double rating;
        public double Rating
        {
            get { return rating; }
            set { rating = value; }
        }
    }
}
