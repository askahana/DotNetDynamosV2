using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class AccountManager
    {
        public static void AddAccount(Customer loggedInUser)
        {
            if (loggedInUser != null && loggedInUser is Customer customer)
            {
                Console.WriteLine("Enter account details:");

                Console.Write("Account Name: ");
                string accountName = Console.ReadLine();

                Console.Write("Currency: ");
                string currency = Console.ReadLine();

                Console.Write("Initial Balance: ");
                decimal initialBalance = Validator.GetValidDecimal();

                int newAccountNumber = GenerateNewAccountNumber(customer);

                Account newAccount = new Account(newAccountNumber, accountName, currency, initialBalance);

                customer.Accounts.Add(newAccount);

                Console.WriteLine($"Account '{newAccount.AccountName}' added successfully with Account Number {newAccount.AccountNumber}.");
            }
        }

        private static int GenerateNewAccountNumber(Customer customer)
        {

            //int maxAccountNumber = customer.Accounts.Count > 0 ? customer.Accounts.Max(acc => acc.AccountNumber) : 0;
            //return maxAccountNumber + 1;
            if (customer != null && customer.Accounts != null && customer.Accounts.Count > 0)
            {
                int maxAccountNumber = customer.Accounts.Max(acc => acc.AccountNumber);
                return maxAccountNumber + 1;
            }
            else
            {
                return 1;
            }
        }
    }
}


