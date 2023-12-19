using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class CustomerManager
    {
        /// <summary>
        /// Ändrat parameter till loggedInCustomer.
        /// Ändrat logoutmetod så den går tillbaka till Start. 
        /// Ändrat metod till static.
        /// </summary>
        /// <param name="loggedInCustomer"></param>
        public static void Menu(Customer loggedInCustomer) //Vi skulle kunna hämta information direkt från LoginSystem här kanske? 
        {
            bool go = true;
            while (go)
            {
                try
                {
                    Console.WriteLine("Customer Menu");
                    Console.WriteLine("1. View account and balance");
                    Console.WriteLine("2. Transfer money between accounts");
                    Console.WriteLine("3. Transfer money to other Customer");
                    Console.WriteLine("4. Open new account");
                    Console.WriteLine("5. Another currency");
                    Console.WriteLine("6. Account history");
                    Console.WriteLine("7. Logg out");
                    Console.Write("Choose meny: ");
                    int svar = Convert.ToInt32(Console.ReadLine());
                    switch (svar)
                    {
                        case 1:
                            Console.Clear();
                            ShowBalance.ShowAccount(loggedInCustomer);
                            break;
                        case 2:
                            Console.Clear();
                            TransferMoney.TransferMoneyBetweenAccount(loggedInCustomer);
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Out of order.");
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.Clear();
                            AccountManager.AddAccount(loggedInCustomer);
                            Console.ReadKey();
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("Out of order.");
                            break;
                        case 6: // Account history
                            Console.Clear();
                            Transaction.ShowTransactionHistory(loggedInCustomer);
                            Console.ReadKey();
                            break;
                        case 7:
                            Console.Clear();
                            Console.WriteLine("Logging out.");
                            LogOut();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Insert number between 1-7.");
                            break;
                    }
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Please enter a Number.");
                }

            }
        }
        private static void LogOut()
        {
            Console.WriteLine("Logged out.");
            Starting_screen.StartProgram();
        }
        //public static int GetMenuChoice()
        //{
        //    int choice;
        //    Console.WriteLine("Customer Menu");
        //    Console.WriteLine("1. View account and balance");
        //    Console.WriteLine("2. Transfer money between accounts");
        //    Console.WriteLine("3. Transfer money to other Customer");
        //    Console.WriteLine("4. Open new account");
        //    Console.WriteLine("5. Another currency");
        //    Console.WriteLine("6. Account history");
        //    Console.WriteLine("7. Logg out");
        //    Console.Write("Choose meny: ");
        //    if (!int.TryParse(Console.ReadLine(), out choice))
        //    {
        //        Console.WriteLine("The number is not valid");
        //    }
        //    return choice;
        //}
    }

    ////private LoginSystem loginSystem;
    ////private User loggedInUser;

    ////public CustomerManager(LoginSystem loginSystem)
    ////{
    ////    this.loginSystem = loginSystem;
    ////}



    //public void Meny(User user) //Vi skulle kunna hämta information direkt från LoginSystem här kanske? 
    //    {
    //        //loggedInUser = user;

    //        bool go = true;
    //        while (go)
    //        {
    //            switch (GetMenuChoice())
    //            {
    //                case 1:
    //                    ShowBalance.ShowAccount(user);
    //                    break;
    //                case 2:
    //                    //TransferMoney.TransferMoneyBetweenAccount(user);
    //                    Console.ReadKey();
    //                    break;
    //                case 3:
    //                    Console.WriteLine("Out of order.");
    //                    Console.ReadKey();
    //                    break;
    //                case 4:
    //                    AccountManager.AddAccount(user);
    //                    Console.ReadKey();
    //                    break;
    //                case 5:
    //                    Console.WriteLine("Out of order.");
    //                    break;
    //                case 6: // Account history
    //                    Transaction.ShowTransactionHistory(user);
    //                    Console.ReadKey();
    //                    break;
    //                case 7:
    //                    Console.WriteLine("Logging out.");
    //                    LogOut();
    //                    break;
    //                default:
    //                    Console.Clear();
    //                    Console.WriteLine("Insert mellan 1-7.");
    //                    Console.ReadKey();
    //                    break;
    //            }
    //        }
    //    }
    //    private void LogOut()
    //    {
    //        Console.WriteLine("Logged out.");
    //        AccountManagementSystem.Assign();
    //    }
    //    public static int GetMenuChoice()
    //    {
    //        int choice;
    //        Console.WriteLine("Customer Meny");
    //        Console.WriteLine("1. View account and balance");
    //        Console.WriteLine("2. Transfer money between accounts");
    //        Console.WriteLine("3. Transfer money to other Customer");
    //        Console.WriteLine("4. Open new account");
    //        Console.WriteLine("5. Another currency");
    //        Console.WriteLine("6. Account history");
    //        Console.WriteLine("7. Logg out");
    //        Console.Write("Choose meny: ");
    //        if (!int.TryParse(Console.ReadLine(), out choice))
    //        {
    //            Console.WriteLine("The number is not valid");
    //        }
    //        return choice;
    //    }
    //}
}
