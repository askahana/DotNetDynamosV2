using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class LoanManager
    {
        public static void RequestPersonalLoan(Customer customer)
        {
            Console.WriteLine("Enter personal loan details:");

            Console.Write("Loan Amount: ");
            decimal loanAmount = Validator.GetValidDecimal();

           
            if (loanAmount > 5 * CalculateTotalBalance(customer))
            {
                Console.WriteLine("Loan request denied. The personal loan amount exceeds the limit (5 times the current balance).");
                return;
            }

            decimal interestRate = InterestManager.GetLoanInterestRate();

            Console.WriteLine($"The loan will have an interest rate of: {interestRate:P}");

            
            DisplayUserAccounts(customer);
            int selectedAccountIndex = Validator.GetValidInt("Enter the account number to add the loan amount: ", 1, customer.Accounts.Count) - 1;
            Account selectedAccount = customer.Accounts[selectedAccountIndex];

            
            selectedAccount.Balance += loanAmount;

            Console.WriteLine($"Personal loan request approved. The loan amount has been added to account {selectedAccount.AccountNumber}. You will need to repay: {loanAmount:C}");
            Console.WriteLine("Press enter to return to the menu");
           
        }

        private static void DisplayUserAccounts(Customer customer)
        {
            for (int i = 0; i < customer.Accounts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Account {customer.Accounts[i].AccountNumber}: {customer.Accounts[i].AccountName} - {customer.Accounts[i].Currency}");
            }
        }

        private static decimal CalculateTotalBalance(Customer customer)
        {
           
            return customer.Accounts.Sum(account => account.Balance);
        }
    }

}

