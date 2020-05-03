using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace DesignPatternsApp.Tracking
{
    public abstract class FoodDelivery
    {
        private readonly List<ICustomer> customers = new List<ICustomer>();
        public string OrderID { get; set; }
        public string RestaurantID { get; set; }
        private string Status;
        public string DeliveryStatus
        {
            get { return Status; }
            set
            {
                if( Status != value)
                {
                    Status = value;
                    Notify();
                }
            }
        }

        public DateTime DeliveryTime
        {
            get { return DateTime.Now; }
        }


        protected FoodDelivery(string RestaurantID, string OrderID, string DeliveryStatus)
        {
            this.RestaurantID = RestaurantID;
            this.OrderID = OrderID;
            this.DeliveryStatus = DeliveryStatus;
        }


        public void Attach(ICustomer customer)
        {
            customers.Add(customer);
        }

        public void Notify()
        {
            foreach(ICustomer customer in customers)
            {
                customer.Update(this);
            }
            Console.WriteLine(string.Empty);
        }

    }
}
