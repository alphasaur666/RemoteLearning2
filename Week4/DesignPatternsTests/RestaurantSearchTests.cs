using DesignPatternsApp.Models;
using DesignPatternsApp.RestaurantSearch;
using DesignPatternsApp.Services;
using DesignPatternsApp.Tracking;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsTests
{
    [TestFixture]
    class RestaurantSearchTests
    {

        [SetUp]
        public void SetUp()
        {
            // for mocks
        }

        [Test]
        public void GetAllRestaurants_WithValidInput_ReturnsExpectedObject()
        {
            InterpreterContext interpreterContext = new InterpreterContext();
            var restaurantList = interpreterContext.GetAllRestaurants();
            Assert.IsInstanceOf(typeof(List<RestaurantModel>), restaurantList);
        }

        [Test]
        public void GetAllRestaurants_WithValidInput_ReturnsNotNullableObject()
        {
            InterpreterContext interpreterContext = new InterpreterContext();
            var restaurantList = interpreterContext.GetAllRestaurants();
            Assert.IsNotNull(restaurantList);
        }

        [Test]
        public void Interpret_WithValidInput_ReturnsEmptyObject()
        {
            InterpreterContext interpreterContext = new InterpreterContext();
            RestaurantLocationExpression restaurantLocationExpression = new RestaurantLocationExpression("Restaurant");
            var result = restaurantLocationExpression.Interpret(interpreterContext);
            Assert.IsEmpty(result);
        }

        [Test]
        public void InterpretClient_WithValidInput_ReturnsExpectedObjectType()
        {
            InterpreterContext interpreterContext = new InterpreterContext();
            RestaurantSearchClient restaurantSearchClient = new RestaurantSearchClient(interpreterContext);
            string searchSentence = string.Format("restaurant by location '{0}'", "str.Caracal");
            var intercept = restaurantSearchClient.Intercept(searchSentence);
            Assert.IsInstanceOf(typeof(List<RestaurantModel>), intercept);
        }
        [Test]
        public void InterpretClient_WithValidInput_IsNotEmpty()
        {
            InterpreterContext interpreterContext = new InterpreterContext();
            RestaurantSearchClient restaurantSearchClient = new RestaurantSearchClient(interpreterContext);
            string searchSentence = string.Format("restaurant by location '{0}'", "str.Caracal");
            var intercept = restaurantSearchClient.Intercept(searchSentence);
            Assert.IsNotEmpty(intercept.ToString());
        }
    }
}
