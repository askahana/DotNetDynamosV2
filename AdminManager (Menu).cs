using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class AdminManager
    {

        public void Menu(Admin loggedInAdmin)
        {
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
                        RegisterNewCustomer.RegisterCustomer(loggedInAdmin);
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
        /// <summary>
        /// Ändrat så att det går tillbaka till Start.
        /// </summary>
        private void LogOut()
        {
            Console.WriteLine("Logged out.");
            Starting_screen.StartProgram();
        }
    }

    //    private AdminLogin loginSystem;
    //    private User loggedInUser;

    //    public AdminManager(AdminLogin loginSystem)
    //    {
    //        this.loginSystem = loginSystem;
    //    }

    //    public void Meny(User user)
    //    {
    //        loggedInUser = user;

    //        bool go = true;
    //        while (go)
    //        {
    //            Console.WriteLine("Admin Menu");
    //            Console.WriteLine("1. Create new user account.");
    //            Console.WriteLine("2. Delete user account.");
    //            Console.WriteLine("3. See User accounts.");
    //            Console.WriteLine("4. Change interest.");
    //            Console.WriteLine("5. Change exchange rate.");
    //            Console.WriteLine("6. Log out.");
    //            int svar = Convert.ToInt32(Console.ReadLine());
    //            switch (svar)
    //            {
    //                case 1:
    //                    RegisterNewCustomer.RegisterCustomer(loginSystem);
    //                    break;
    //                case 2:
    //                    Console.WriteLine("Out of order.");
    //                    Console.ReadKey();
    //                    break;
    //                case 3:
    //                    ShowAllCustomer.ShowAllInfo();
    //                    break;
    //                case 4:
    //                    Console.WriteLine("Out of order.");
    //                    Console.ReadKey();
    //                    break;
    //                case 5:
    //                    Converter.InsertRate();
    //                    break;
    //                case 6:
    //                    Console.WriteLine("Logging out.");
    //                    LogOut();
    //                    break;
    //                default:
    //                    Console.WriteLine("Wrong input, try again.");
    //                    break;
    //            }
    //        }
    //    }

    //    private void LogOut()
    //    {
    //        Console.WriteLine("Logged out.");
    //        AccountManagementSystem.Assign();
    //    }
    //}
}
