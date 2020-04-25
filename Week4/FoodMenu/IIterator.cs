using System;
using System.Collections.Generic;
using System.Runtime;
using System.Text;

namespace DesignPatternsApp.FoodMenu
{
    public interface IIterator
    {
        bool HasNext();
        object Next();
    }
}
