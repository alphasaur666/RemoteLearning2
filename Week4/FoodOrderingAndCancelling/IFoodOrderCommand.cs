using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.FoodOrdering
{
    public interface IFoodOrderCommand
    {
        void ExecuteCommand();
    }
}
