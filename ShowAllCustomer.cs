using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class ShowAllCustomer
    {
        public static void ShowAllInfo()
        {
            bool go = true;

            while (go)
            {
                Console.WriteLine("Type of user account:");
                Console.WriteLine("1. Admin.");
                Console.WriteLine("2. Customer.");
                Console.WriteLine("3. Exit to main menu.");
                int choice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (choice)
                {
                    case 1:
                        ShowAdminInfo();
                        break;

                    case 2:
                        ShowCustomerInfo();
                        break;

                    case 3:
                        go = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter '1', '2' or '3'.");
                        break;
                }
            }
        }
        public static void ShowAdminInfo()
        {
            // Show a numbered list of admin usernames for selection
            int adminNumber = 1;
            foreach (KeyValuePair<string, User> user in DataManager.userList)
            {
                if (user.Value is Admin admin)
                {
                    Console.WriteLine($"{adminNumber}. {admin.UserName} {admin.FirstName} {admin.LastName}");
                    adminNumber++;
                }
            }
            Console.WriteLine("Press any key to Exit.");
            Console.ReadKey();
            Console.Clear();
        }

        public static void ShowCustomerInfo()
        {
            Console.WriteLine("Choose a customer to see more information:");

            // Show a numbered list of customer usernames for selection
            int customerNumber = 1;
            foreach (KeyValuePair<string, User> user in DataManager.userList)
            {
                if (user.Value is Customer customer)
                {
                    Console.WriteLine($"{customerNumber}. {customer.UserName} {customer.FirstName} {customer.LastName}");
                    customerNumber++;
                }
            }

            // Allow the user to choose a customer by entering the corresponding number
            int selectedCustomerNumber = Convert.ToInt32(Console.ReadLine());
            Console.Clear();

            // Display detailed information for the selected customer
            int currentCustomerNumber = 1;
            foreach (KeyValuePair<string, User> user in DataManager.userList)
            {
                if (user.Value is Customer customer)
                {
                    if (currentCustomerNumber == selectedCustomerNumber)
                    {
                        Console.WriteLine($"Customer UserName: {customer.UserName}");
                        Console.WriteLine($"Customer FirstName: {customer.FirstName}");
                        Console.WriteLine($"Customer LastName: {customer.LastName}");

                        Console.WriteLine("Accounts:");
                        if (customer.Accounts != null)
                        {
                            foreach (Account account in customer.Accounts)
                            {
                                Console.WriteLine($"Account Number: {account.AccountNumber}");
                                Console.WriteLine($"Account Name: {account.AccountName}");
                                Console.WriteLine($"Balance: {account.Balance}");
                                Console.WriteLine($"Currency: {account.Currency}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No accounts for this user.");
                        }
                        Console.WriteLine("---------------------------");

                        Console.WriteLine("Press any key to Exit.");
                        Console.ReadKey();
                        Console.Clear();
                    }

                    currentCustomerNumber++;
                }
            }
        }
    }
}
