using DesignPatternsApp.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsTests
{
    [TestFixture]
    class UserModelTests
    {

        [Test]
        public void GetUser_WithValidInput_ReturnsExpectedObjectNotNull()
        {
            UserModel userModel = new UserModel();
            var user = userModel.GetUser("Mary12" , "Mariana" , "0727763747" , "Str. Caracal nr. 76");
            Assert.IsNotNull(user);

        }
            
    }
}
