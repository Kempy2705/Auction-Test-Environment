using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auction_Test_Environment
{
    public class auctionHouse
    {
        //Save Data Database filepath.
        private string savedatafile = @"C:\Users\drdke\auctionHouseUsers.csv";
        //A list of all current users of the system.
        public List<auctionHouseUser> accounts = new List<auctionHouseUser>();

        //Constructor to create an instance of the users in the Auction House
        public auctionHouse()
        {

        }

        /// <summary>
        /// Prompts the user for input, creates and returns a Auction User.
        /// </summary>
        /// <returns></returns>
        public auctionHouseUser createUser()
        {
            Console.WriteLine("Please Enter Your Name: ");
            string userName = Console.ReadLine();
            Console.WriteLine("Please Enter Your Email Address: ");
            string emailaddress = Console.ReadLine();
            Console.WriteLine("Please Create a Password For Your Account: ");
            string userpassword = Console.ReadLine();

            auctionHouseUser newuser = new auctionHouseUser(userName, emailaddress, userpassword);

            return newuser;
        }


        /// <summary>
        /// Adds Newly Created users to the accounts list instance
        /// </summary>
        /// <param name="user"></param>
        public void AddUserToList(auctionHouseUser user)
        {
            accounts.Add(user);
        }


        public void ToString(auctionHouseUser user)
        {

        }

        /// <summary>
        /// This Method Writes all the users in the system to CSV file from the accounts list.
        /// Acts as a database.
        /// </summary>
        public void saveusers()
        {
            //The variables for the String Builder
            string separator = ",";
            StringBuilder sb = new StringBuilder();

            // Creating the headings for the CSV File
            string[] headings = { "Name", "Email Address", "Password" };
            sb.AppendLine(string.Join(separator, headings));

            foreach (auctionHouseUser user in accounts)
            {
                //Build the string builder and add the users 
                string[] newLine = { user.Name, user.Email, user.Password };
                sb.AppendLine(string.Join(separator, newLine));
            }
            //Attempt to save the data to the file
            try
            {
                //Clear the contents of the file.
                FileStream clearfile = File.Open(savedatafile, FileMode.Open);
                clearfile.SetLength(0);
                clearfile.Close();

                //Overwrite the data by saving the updated list of account holders.
                File.AppendAllText(savedatafile, sb.ToString());
                Console.WriteLine("The data has been successfully saved to the CSV file");
            }
            catch
            {   //Display Error if failure.
                Console.WriteLine("Data could not be written to the CSV file.");
            }

        }


        public void loadusers()
        {   
            //Iniate A Stream Reader to read the database.
            using (StreamReader sr = new StreamReader(savedatafile))
            {
                // Variable for each user
                string savedusers;
                


                //While line is not null, read the line and split each variable into a separate string.
                while ((savedusers = sr.ReadLine()) != null)
                {

                    string[] linearray = savedusers.Split(",");
                    string name = linearray[0].ToString();
                    string email = linearray[1].ToString();
                    string password = linearray[2].ToString();
                    
                    // Create a AuctionUser Type Object from the Database and add it to the Auction System Accounts List.
                    try
                    {
                        if (name != "Name" && email != "Email" && password != "Password")
                        {
                         auctionHouseUser user = new auctionHouseUser(name, email, password);
                         accounts.Add(user);
                        }
                    }

                    // Throw Exception if the system tries to add the titles from the Database.
                    catch
                    {
                        Console.WriteLine("Invalid User, Could not be added.");
                    }
                    

                }
            }

        }

        



    }
}


