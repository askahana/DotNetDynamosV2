using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class InterestManager
    {
        private static decimal savingsInterestRate = 0.02M; 
        private static decimal loanInterestRate = 0.05M;

        internal static void SetSavingsInterestRate(decimal newRate)
        {
            savingsInterestRate = newRate;
            Console.WriteLine($"Savings interest rate set to: {savingsInterestRate:P}");
        }

        public static void SetLoanInterestRate(decimal newRate)
        {
            loanInterestRate = newRate;
            Console.WriteLine($"Loan interest rate set to: {loanInterestRate:P}");
        }

        public static void DisplayInterestRates()
        {
            Console.WriteLine($"Current Savings Interest Rate: {savingsInterestRate:P}");
            Console.WriteLine($"Current Loan Interest Rate: {loanInterestRate:P}");
        }

        public static void AdminSetInterestRates()
        {
            Console.WriteLine("Admin, choose an option:");
            Console.WriteLine("1. Set Savings Interest Rate");
            Console.WriteLine("2. Set Loan Interest Rate");
      

            int option = Validator.GetValidInt("Enter your choice: ", 1, 2);
            Console.Clear();

            switch (option)
            {
                case 1:
                    Console.Write("Enter new Savings Interest Rate: ");
                    decimal newSavingsRate = Validator.GetValidDecimal();
                    SetSavingsInterestRate(newSavingsRate);
                    break;
                case 2:
                    Console.Write("Enter new Loan Interest Rate: ");
                    decimal newLoanRate = Validator.GetValidDecimal();
                    SetLoanInterestRate(newLoanRate);
                    break;

            }
        }



        internal static decimal SavingsInterestRate()
        {
            return savingsInterestRate;
        }

        internal static decimal GetLoanInterestRate()
        {
            return loanInterestRate;
        }
    }
}
