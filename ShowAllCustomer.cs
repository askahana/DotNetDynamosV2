using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class ShowAllCustomer
    {
        public static void ShowAllInfo()        // Show all customers all info.
        {
            foreach (KeyValuePair<string, User> user in DataManager.userList)
            {
                Console.WriteLine($"UserName: {user.Value.UserName}");
                Console.WriteLine($"Password: {user.Value.PassWord}");
                if (user.Value is Customer customer && customer.Accounts != null)
                {
                    Console.WriteLine("Accounts:");
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
            }
        }
    }
}
