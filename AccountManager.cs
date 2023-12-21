using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class AccountManager
    {
        /// <summary>
        /// Ändrat till loggedInCustomer /N
        /// 2023-12-16
        /// </summary>
        /// <param name="loggedInCustomer"></param>
        public static void AddAccount(Customer loggedInCustomer)
        {
            if (loggedInCustomer is Customer customer)
            {
                Console.WriteLine("Enter account details:");

                Console.Write("Account Name: ");
                string accountName = Console.ReadLine();

                Console.Write("Currency: ");
                string currency = Console.ReadLine();

                Console.Write("Initial Balance: ");
                decimal initialBalance = Validator.GetValidDecimal();

                Console.WriteLine("Choose the account type:");
                Console.WriteLine($"1. Savings Account (with interest, {InterestManager.SavingsInterestRate():P})");
                Console.WriteLine("2. Regular Account (without interest)");

                int accountTypeChoice = Validator.GetValidInt("Enter your choice: ", 1, 2);

                

                decimal interestRate = (accountTypeChoice == 1) ? InterestManager.SavingsInterestRate() : 0.0M;

                int newAccountNumber = GenerateNewAccountNumber(customer);

                int sortOrder = loggedInCustomer.Accounts.Count + 1;

                Account newAccount;

                if (accountTypeChoice == 1)
                {
                    newAccount = new SavingsAccount(newAccountNumber, accountName, currency, initialBalance, interestRate, sortOrder);
                    Console.WriteLine($"Interest Rate: {interestRate:P}");
                    decimal earnedInterest = CalculateEarnedInterest(initialBalance, interestRate);
                    Console.WriteLine($"You will earn {earnedInterest:C} in interest.");
                }
                else
                {
                    newAccount = new Account(newAccountNumber, accountName, currency, initialBalance, sortOrder);
                }

                customer.Accounts.Add(newAccount);

                Console.WriteLine($"Account '{newAccount.AccountName}' added successfully with Account Number {newAccount.AccountNumber}.");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private static decimal CalculateEarnedInterest(decimal balance, decimal interestRate)
        {
            
            return balance * interestRate;
        }

        public static int GenerateNewAccountNumber(Customer customer)
        {
            int maxAccountNumber = customer.Accounts.Count > 0 ? customer.Accounts.Max(acc => acc.AccountNumber) : 0;
            return maxAccountNumber + 1;
        }
    }
}

    //    public static void AddAccount(User loggedInUser)
    //    {
    //        if (loggedInUser is Customer customer)
    //        {
    //            Console.WriteLine("Enter account details:");

    //            Console.Write("Account Name: ");
    //            string accountName = Console.ReadLine();

    //            Console.Write("Currency: ");
    //            string currency = Console.ReadLine();

    //            Console.Write("Initial Balance: ");
    //            decimal initialBalance = Validator.GetValidDecimal();

    //            int newAccountNumber = GenerateNewAccountNumber(customer);

    //            Account newAccount = new Account(newAccountNumber, accountName, currency, initialBalance);

    //            customer.Accounts.Add(newAccount);

    //            Console.WriteLine($"Account '{newAccount.AccountName}' added successfully with Account Number {newAccount.AccountNumber}.");
    //        }
    //    }

    //    private static int GenerateNewAccountNumber(Customer customer)
    //    {

    //        int maxAccountNumber = customer.Accounts.Count > 0 ? customer.Accounts.Max(acc => acc.AccountNumber) : 0;
    //        return maxAccountNumber + 1;
    //    }
    //}

