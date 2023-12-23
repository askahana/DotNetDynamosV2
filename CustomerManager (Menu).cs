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
                    Console.WriteLine("1. Withdraw and deposit");
                    Console.WriteLine("2. Account services and loans");
                    Console.WriteLine("3. Transfer services");
                    Console.WriteLine("4. Logg out");
                    Console.Write("Enter menu choice: ");
                    int choice1 = Convert.ToInt32(Console.ReadLine());
                    switch (choice1)
                    {
                        case 1:
                            Console.Clear();
                            Console.WriteLine
                                ("Withdraw and deposit:\n" +
                                "1. Withdraw.\n" +
                                "2. Deposit. \n" +
                                "Press enter to return to menu."
                                );
                            int choice2 = Convert.ToInt32(Console.ReadLine());
                            switch (choice2)
                            {
                                case 1:
                                    Console.Clear();
                                    TransferMoney.Withdraw(loggedInCustomer);
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.Clear();
                                    TransferMoney.Deposit(loggedInCustomer);
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.ReadKey();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Insert number between 1-2.");
                                    continue;
                            }
                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine
                                ("Account services:\n" +
                                "1. View accounts and balance.\n" +
                                "2. Open new account. \n" +
                                "3. Account history.\n" +
                                "4. Personal loan.\n\n" +
                                "Press enter to return to menu."
                                );
                            int choice3 = Convert.ToInt32(Console.ReadLine());
                            switch (choice3)
                            {
                                case 1:
                                    Console.Clear();
                                    ShowBalance.ShowAccount(loggedInCustomer);
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.Clear();
                                    AccountManager.AddAccount(loggedInCustomer);
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    Console.Clear();
                                    Transaction.ShowTransactionHistory(loggedInCustomer);
                                    Console.ReadKey();
                                    break; 
                                case 4:
                                    Console.Clear();
                                    LoanManager.RequestPersonalLoan(loggedInCustomer);
                                    Console.ReadKey();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Insert number between 1-4.");
                                    break;
                            }
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine
                                ("Transfer services:\n" +
                                "1. Transfer between accounts.\n" +
                                "2. Transfer to other person. \n" +
                                "3. Show Transaction History.\n\n" +
                                "Press enter to return to menu."
                                );
                            int choice4 = Convert.ToInt32(Console.ReadLine());
                            switch (choice4)
                            {
                                case 1:
                                    Console.Clear();
                                    TransferMoney.TransferMoneyBetweenAccount(loggedInCustomer);
                                    Console.ReadKey();
                                    break;
                                case 2:
                                    Console.Clear();
                                    TransferMoney.TransferMoeneyToOthers(loggedInCustomer);
                                    Console.ReadKey();
                                    break;
                                case 3:
                                    Console.Clear();
                                    Transaction.ShowTransactionHistory(loggedInCustomer);
                                    Console.ReadKey();
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.ReadKey();
                                    break;
                                default:
                                    Console.Clear();
                                    Console.WriteLine("Insert number between 1-3.");
                                    break;
                            }
                            
                            break;
                        case 4:
                            Console.Clear();
                            LogOut(loggedInCustomer);
                            Console.ReadKey();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Insert number between 1-4.");
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
        public static void LogOut(Customer loggedInCustomer)
        {
            Console.Clear();
            Console.WriteLine("Logged out.");
            loggedInCustomer = null;
            Starting_screen.StartProgram();
        }
       
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
