using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.Tracking
{
    public interface ICustomer
    {
        void Update(FoodDelivery foodDelivery);
    }
}
