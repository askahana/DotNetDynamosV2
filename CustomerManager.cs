using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class CustomerManager
    {
        private LoginSystem loginSystem;
        private User loggedInUser;

        public CustomerManager(LoginSystem loginSystem)
        {
            this.loginSystem = loginSystem;
        }

        public void Meny(User user)
        {
            loggedInUser = user;

            bool go = true;
            while (go)
            {
                switch (GetMenuChoice())
                {
                    case 1:
                        ShowBalance.ShowAccount(loggedInUser);
                        break;
                    case 2:
                        Console.WriteLine("Out of order.");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.WriteLine("Out of order.");
                        Console.ReadKey();
                        break;
                    case 4:
                        AccountManager.AddAccount(loggedInUser);
                        Console.ReadKey();
                        break;
                    case 5:
                        Converter.ConvertMoney(loggedInUser);
                        break;
                    case 6:
                        Console.WriteLine("Out of order.");
                        Console.ReadKey();
                        break;
                    case 7:
                        Console.WriteLine("Logging out.");
                        LogOut();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Insert mellan 1-7.");
                        Console.ReadKey();
                        break;
                }
            }
        }
        private void LogOut()
        {
            Console.WriteLine("Logged out.");
            AccountManagementSystem.Assign();
        }
        public static int GetMenuChoice()
        {
            int choice;
            Console.WriteLine("Customer Meny");
            Console.WriteLine("1. View account and balance");
            Console.WriteLine("2. Transfer money between accounts");
            Console.WriteLine("3. Transfer money to other Customer");
            Console.WriteLine("4. Open new account");
            Console.WriteLine("5. Another currency");
            Console.WriteLine("6. Account history");
            Console.WriteLine("7. Logg out");
            Console.Write("Choose meny: ");
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("The number is not valid");
            }
            return choice;
        }
    }
}
