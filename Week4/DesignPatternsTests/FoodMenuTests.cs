using DesignPatternsApp.FoodMenu;
using DesignPatternsApp.FoodOrdering;
using DesignPatternsApp.Models;
using DesignPatternsApp.Services;
using DesignPatternsApp.Tracking;
using NUnit.Framework;
using System.Collections.Generic;

namespace DesignPatternsTests
{
    [TestFixture]
    public class FoodMenuTests
    {
        [SetUp]
        public void Setup()
        {
                  
        }

        [Test]
        public void PrintFoodMenu_WithValidInput_ReturnsExpectedType()
        {
            RestaurantOperator restaurant = new RestaurantOperator("1");
            var foodMenu = restaurant.PrintFoodMenu();
            Assert.IsInstanceOf(typeof(List<FoodMenuModel>), foodMenu);
        }

        [Test]
        public void GetFoodMenuItems_WithValidInput_ReturnsNotNullableValue()
        {
            FoodMenuService foodMenuService = new FoodMenuService("1");
            var foodMenuItems = foodMenuService.getFoodMenu("1");
            Assert.IsNotNull(foodMenuItems);

        }


        [TearDown]
        public void TearDown()
        {

        }
    }
}