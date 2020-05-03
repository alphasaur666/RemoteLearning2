using DesignPatternsApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.RestaurantSearch
{
    public abstract class AbstractExpression
    {
        public abstract List<RestaurantModel> Interpret(InterpreterContext context);
    }
}
