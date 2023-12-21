using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class LoanManager
    {
        private static bool hasTakenLoan = false;
        public static void RequestPersonalLoan(Customer customer)
        {

            if (hasTakenLoan)
            {
                Console.WriteLine("You have already taken a loan. Only one loan is allowed.");
                return;
            }
            Console.WriteLine("Enter personal loan details:");

            Console.Write("Loan Amount: ");
            decimal loanAmount = Validator.GetValidDecimal();

           
            decimal totalBalance = CalculateTotalBalance(customer);
            decimal totalBalanceWithLoan = totalBalance + loanAmount;

            if (loanAmount > 5 * totalBalanceWithLoan)
            {
                Console.WriteLine("Loan request denied. The personal loan amount exceeds the limit (5 times the total balance including the loan amount).");
                return;
            }

            decimal interestRate = InterestManager.GetLoanInterestRate();

            Console.WriteLine($"The loan will have an interest rate of: {interestRate:P}");

            DisplayUserAccounts(customer);
            int selectedAccountIndex = Validator.GetValidInt("Enter the account number to add the loan amount: ", 1, customer.Accounts.Count) - 1;
            Account selectedAccount = customer.Accounts[selectedAccountIndex];

           
            selectedAccount.Balance += loanAmount;
            selectedAccount.LoanAmount += loanAmount;

            hasTakenLoan = true;

            Console.WriteLine($"Personal loan request approved. The loan amount of {loanAmount:C} has been added to account {selectedAccount.AccountNumber}.");

            
            decimal repaymentAmount = CalculateRepaymentAmount(loanAmount, interestRate);
            Console.WriteLine($"You will need to repay: {repaymentAmount:C}");

            Console.WriteLine("Press enter to return to the menu");
            Console.ReadKey();
            Console.Clear();
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
         
            return customer.Accounts.Sum(account => account.Balance + account.LoanAmount);
        }

        private static decimal CalculateRepaymentAmount(decimal loanAmount, decimal interestRate)
        {
          
            decimal repaymentAmount = loanAmount * (1 + interestRate);
            return repaymentAmount;
        }
    }

}

