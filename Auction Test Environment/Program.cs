namespace Auction_Test_Environment
{
    class Program
    {
       static void Main(string[] args)
        {
            string savedatafile = @"C:\Users\drdke\auctionHouseUsers.csv";

            //Instantiate the bank and the menu.
            auctionHouse auctionhouse = new auctionHouse();
            MenuItems menuItems = new MenuItems(auctionhouse);

            //Attempt to Load the Users in the system, if a file does not exist, create one.
            try
            {
                auctionhouse.loadusers();
            }
            catch
            {
                using (StreamWriter createfile = File.AppendText(savedatafile));
            }

            //Temp Add of users
            /*
            auctionHouseUser peter = new auctionHouseUser("peter", "peter@gmail.com.com", "1234asdf");
            auctionHouseUser Julie = new auctionHouseUser("Julie", "julie@gmail.com.com", "1234asdf");
            auctionHouseUser Andrew = new auctionHouseUser("Andrew", "andy@gmail.com.com", "1234asdf");
            auctionHouseUser Levin = new auctionHouseUser("Levin", "Levin@gmail.com.com", "1234asdf");
            auctionHouseUser Geralt = new auctionHouseUser("Geralt", "geralt@gmail.com.com", "1234asdf");

            auctionhouse.AddUserToList(peter);
            auctionhouse.AddUserToList(Julie);
            auctionhouse.AddUserToList(Andrew);
            auctionhouse.AddUserToList(Levin);  
            auctionhouse.AddUserToList(Geralt);
            */


            //Welcome the users
            Console.WriteLine(" Welcome to the auction house system!");
            //Run main menu
           menuItems.mainMenu();
           
            

        //CREATE PRODUCT CLASS AND EXPERIMENT WITH CREATING A PRODUCT STACK.
        
        }




    }
 
} 
    
