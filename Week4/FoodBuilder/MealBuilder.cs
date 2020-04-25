using DesignPatternsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.FoodBuilders
{
    public class MealBuilder
    {
        public Meal meal;
        public void PrepareMeal(List<FoodMenuModel> foodMenu)
        {
            meal = new Meal();
            meal.AddFoodItem(foodMenu);
        }
    }
}
