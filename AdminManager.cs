using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class AdminManager
    {
        private LoginSystem loginSystem;
        private User loggedInUser;

        public AdminManager(LoginSystem loginSystem)
        {
            this.loginSystem = loginSystem;
        }

        public void Meny(User user)
        {
            loggedInUser = user;

            bool go = true;
            while (go)
            {
                Console.WriteLine("Admin Menu");
                Console.WriteLine("1. Create new user account.");
                Console.WriteLine("2. Delete user account.");
                Console.WriteLine("3. See User accounts.");
                Console.WriteLine("4. Change interest.");
                Console.WriteLine("5. Change exchange rate.");
                Console.WriteLine("6. Log out.");
                int svar = Convert.ToInt32(Console.ReadLine());
                switch (svar)
                {
                    case 1:
                        RegisterNewCustomer.RegisterCustomer(loginSystem);
                        break;
                    case 2:
                        Console.WriteLine("Out of order.");
                        Console.ReadKey();
                        break;
                    case 3:
                        ShowAllCustomer.ShowAllInfo();
                        break;
                    case 4:
                        InterestManager.DisplayInterestRates();
                        Console.WriteLine("");
                        InterestManager.AdminSetInterestRates();
                        Console.ReadKey();
                        break;
                    case 5:
                        Converter.InsertRate();
                        break;
                    case 6:
                        Console.WriteLine("Logging out.");
                        LogOut();
                        break;
                    default:
                        Console.WriteLine("Wrong input, try again.");
                        break;
                }
            }
        }

        private void LogOut()
        {
            Console.WriteLine("Logged out.");
            AccountManagementSystem.Assign();
        }
    }
}
