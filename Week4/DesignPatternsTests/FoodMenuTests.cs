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
            //Mocks if i had :)
                  
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

        [Test]
        public void CreateFoodMenuIterator_WithValidInput_ReturnsExpectedObject()
        {
            FoodMenu foodMenu = new FoodMenu("1");
            var foodMenuIterator = foodMenu.CreateFoodMenuIterator();
            Assert.IsInstanceOf(typeof(RestaurantFoodMenuIterator), foodMenuIterator);
        }

        [Test]
        public void CreateFoodMenuIterator_WithValidInput_ReturnsNotNullableVAlue()
        {
            FoodMenu foodMenu = new FoodMenu("1");
            var foodMenuIterator = foodMenu.CreateFoodMenuIterator();
            Assert.IsNotNull(foodMenuIterator);
        }
    }
}