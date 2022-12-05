using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_Test_Environment
{

public class auctionHouseUser
    {
        private string name;
        private string email;
        private string password;
        

        //Constructor for Users
        public auctionHouseUser(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.Password = password;
            
          
        }


        // Getters/Setters for each property for the users of the Auction house
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public void printUser(auctionHouseUser user)
        {
            Console.WriteLine(user.Name + " " + user.Email + " " +  user.Password);
        }

       





    }
}
