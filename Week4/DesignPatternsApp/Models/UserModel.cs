using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatternsApp.Models
{
    public class UserModel
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public double Amount { get; set; }


        public UserModel(string Username, string FullName, string PhoneNumber , string Adress, double Amount)
        {
            this.Username = Username;
            this.FullName = FullName;
            this.PhoneNumber = PhoneNumber;
            this.Adress = Adress;
            this.Amount = Amount;

        }

        public UserModel()
        {

        }

        public UserModel GetUser()
        {
            string Username, FullName, PhoneNumber, Adress;

            Console.WriteLine("Insert username:");
            Username = Console.ReadLine();
            Console.WriteLine("Insert full name:");
            FullName = Console.ReadLine();
            Console.WriteLine("Insert phone number:");
            PhoneNumber = Console.ReadLine();
            Console.WriteLine("Insert adress:");
            Adress = Console.ReadLine();
            Amount = 0;

            UserModel generatedUserModel = new UserModel(Username, FullName, PhoneNumber, Adress, Amount);
            return generatedUserModel;
        }

        public UserModel GetUser(string Username, string FullName, string PhoneNumber, string Adress) // for testing purposes
        {              
            Amount = 0;
            UserModel generatedUserModel = new UserModel(Username, FullName, PhoneNumber, Adress, Amount);
            return generatedUserModel;
        }
    }
}
