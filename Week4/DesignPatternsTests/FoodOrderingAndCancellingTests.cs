using DesignPatternsApp.FoodOrdering;
using DesignPatternsApp.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsTests
{
    [TestFixture]
    class FoodOrderingAndCancellingTests
    {
        [Test]
        public void OrderFood_WithValidInput_IsNotEmpty()
        {
            UserModel user = new UserModel();
            Food food = new Food();
            var orderedFood = food.OrderFood("1",user);
            Assert.IsNotEmpty(orderedFood);
        }       
    }
}
