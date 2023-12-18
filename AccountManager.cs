using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class AccountManager
    {
        public static void AddAccount(User loggedInUser)
        {
            if (loggedInUser is Customer customer)
            {
                Console.WriteLine("Enter account details:");

                Console.Write("Account Name: ");
                string accountName = Console.ReadLine();

                Console.Write("Currency: ");
                string currency = Console.ReadLine();

                Console.Write("Initial Balance: ");
                decimal initialBalance = Validator.GetValidDecimal();

                Console.WriteLine("Choose the account type:");
                Console.WriteLine($"1. Savings Account (with interest)");
                Console.WriteLine("2. Regular Account (without interest)");

                int accountTypeChoice = Validator.GetValidInt("Enter your choice: ", 1, 2);

                decimal interestRate = (accountTypeChoice == 1) ? InterestManager.SavingsInterestRate() : 0.0M;

                int newAccountNumber = GenerateNewAccountNumber(customer);

                Account newAccount;

                if (accountTypeChoice == 1)
                {
                    newAccount = new SavingsAccount(newAccountNumber, accountName, currency, initialBalance, interestRate);
                    Console.WriteLine($"Interest Rate: {interestRate:P}");
                }
                else
                {
                    newAccount = new Account(newAccountNumber, accountName, currency, initialBalance);
                }

                customer.Accounts.Add(newAccount);

                Console.WriteLine($"Account '{newAccount.AccountName}' added successfully with Account Number {newAccount.AccountNumber}.");
               
                Console.Clear();
            }
        }

        private static int GenerateNewAccountNumber(Customer customer)
        {
            int maxAccountNumber = customer.Accounts.Count > 0 ? customer.Accounts.Max(acc => acc.AccountNumber) : 0;
            return maxAccountNumber + 1;
        }
    }
}
