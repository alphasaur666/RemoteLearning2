using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.FoodMenu
{
    public interface IFoodMenu
    {
        IIterator CreateFoodMenuIterator();
    }
}
