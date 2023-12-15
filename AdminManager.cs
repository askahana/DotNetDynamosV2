using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class AdminManager
    {
        private LoginAdmin loginSystem;
        private Admin loggedInUser;

        public AdminManager(LoginAdmin loginSystem)
        {
            this.loginSystem = loginSystem;
        }

        public void Meny(Admin user)
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
                        Console.WriteLine("Out of order.");
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

        private static void LogOut()
        {
            //Console.WriteLine("Logged out.");
            //AccountManagementSystem.Assign();
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Vänligen ange din roll:");
                Console.WriteLine("1.Customer");
                Console.WriteLine("2. Admin");
                Console.WriteLine("3. Exit");
                int role = Convert.ToInt32(Console.ReadLine());

                switch (role)
                {
                    case 1:
                        Console.WriteLine("Välkommen som kund!");
                        AccountManagementSystem.Assign();
                        break;
                    case 2:
                        Console.WriteLine("Välkommen som administratör!");
                        AccountManagementSystem.AssignAdmin();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Okänd roll. Vänligen ange antingen 'customer' eller 'admin'.");
                        break;
                }
            }
        }
    }
}
