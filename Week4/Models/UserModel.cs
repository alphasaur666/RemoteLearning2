using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.Models
{
    public class UserModel
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public double Amount { get; set; }


        public UserModel(string UserID, string UserName, string PhoneNumber , string Adress, double Amount)
        {
            this.UserID = UserID;
            this.UserName = UserName;
            this.PhoneNumber = PhoneNumber;
            this.Adress = Adress;
            this.Amount = Amount;

        }

        public UserModel()
        {

        }

        public UserModel GetUser()
        {
            string UserID, UserName, PhoneNumber, Adress;

            Console.WriteLine("Insert user id:");
            UserID = Console.ReadLine();
            Console.WriteLine("Insert user name:");
            UserName = Console.ReadLine();
            Console.WriteLine("Insert phone number:");
            PhoneNumber = Console.ReadLine();
            Console.WriteLine("Insert adress:");
            Adress = Console.ReadLine();
            Amount = 0;

            UserModel generatedUserModel = new UserModel(UserID, UserName , PhoneNumber, Adress, Amount);
            return generatedUserModel;
        }
    }
}
