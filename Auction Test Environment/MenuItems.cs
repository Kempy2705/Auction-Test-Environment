using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_Test_Environment
{
    public class MenuItems
    {

        /// <summary>
        /// Reference to the auction house in question.
        /// </summary>
        private auctionHouse auctionhouse;
        /// <summary>
        /// Reference to the menu in question.
        /// </summary>
        public MenuItems(auctionHouse auctionhouse)
        {
            this.auctionhouse = auctionhouse;   
        }

        //Constant Value to show the menu.
        private bool showmenu = true;
        //Constant to exit environment.
        private const string EXIT = "3";
        //Constant to display options
        private const string PROMPT = "Please Select from the following options";
        private const string INVALID = "You selected an invalid option, please try again";

        /// <summary>
        /// The following method displays the menu to login or register into the system and prompts the user for input.
        /// </summary>
           public void mainMenu()
        {
            string useroption = "";
            while (showmenu)
            {
                Console.WriteLine("*** Entry Menu ***");
                Console.WriteLine(PROMPT);
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Log In");
                Console.WriteLine("3. Exit");
                useroption = Console.ReadLine();

                if (useroption == "1")
                {
                    Console.WriteLine("*** Register ***");
                    auctionHouseUser newUser = auctionhouse.createUser();
                    auctionhouse.AddUserToList(newUser);
                }
                else if (useroption == "2")
                {
                    Console.WriteLine("You have selected Log In");
                    logInMenu();
                    showmenu = false;
                }
                else if (useroption == EXIT)
                {
                    Console.WriteLine("You have selected Exit, Goodbye!");
                    
                    //Test to see if the save load function works.
                    /*if (auctionhouse.accounts.Count > 0)
                    foreach (auctionHouseUser person in auctionhouse.accounts)
                    {
                        person.printUser(person);
                    }
                    else
                    {
                        Console.WriteLine("The System is empty.");
                    }
                    */
                    
                    //Saves the data before safely exiting the program.
                    auctionhouse.saveusers();
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine(INVALID);
                    useroption = "0";
                }
            }
        }

        
        public void logInMenu()
        {   
            // Initiate Variables for current user and entered values by user.
            string enteredemail = "";
            string userpassword = "";
            auctionHouseUser currentuser;
            while (showmenu)
            {
                try
                {   //Prompt the user to enter their email and check against the database.
                    //If no match is found, prompt again.
                    Console.WriteLine("Please enter your email address: ");
                    enteredemail = Console.ReadLine();
                    currentuser = auctionhouse.accounts.FirstOrDefault(a => a.Email == enteredemail);
                    if (currentuser != null)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Email, please try again.");
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid Email, please try again.");
                }
            }
                //Prompt the user for the password and checks against the appropriate user.
                //If passed, the system will log in, otherwise prompting them again.
                Console.WriteLine("Please enter your Password: ");
                while (showmenu)
                {
                    try
                    {
                    userpassword = Console.ReadLine();
                    currentuser = auctionhouse.accounts.FirstOrDefault(a => a.Email == enteredemail);
                    if (userpassword == currentuser.Password)
                    {
                        { break; }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect Password, please try again");
                    }
                    }
                    catch
                    {
                        Console.WriteLine("Incorrect Password, please try again");
                    }
                }

                //Display login success message.
                Console.WriteLine("You have successfully logged in.");
            usermenu();                 
            //Here is where auction menu function will live.
            
        }
        

        public void usermenu()
        {
            //Keep the menu open until the user selects a command.
            while (showmenu)
            {
                //Display the options for the user and prompt a response.
                Console.WriteLine(PROMPT);
                Console.WriteLine("1. View Products For Sale");
                Console.WriteLine("2. View My Items");
                Console.WriteLine("3. List Item for Auction");
                Console.WriteLine("4. Log Out");
                string useroption = Console.ReadLine();

                if (useroption == "1")
                {

                }
                else if (useroption == "2")
                {

                }
                else if (useroption == "3")
                {

                }
                else if (useroption == "4")
                {
                    mainMenu();
                }
                else
                {   //Display message to prompt new selection.
                    Console.WriteLine(INVALID);
                }
            }
        }



    }
}
