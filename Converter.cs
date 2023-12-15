using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class Converter
    {
        public static decimal Yen { get; set; } = 14.0M; // ca 14
        public static decimal Euro { get; set; } = 0.089M;  // ca 0.9
        public static void InsertRate() // Here administrater can change the exchange rate.
        {
            Console.WriteLine("Insert todays exchange rate.");
            Console.Write("Yen: ");
            Yen = Validator.GetValidDecimal();
            Console.Write("Euro: ");
            Euro = Validator.GetValidDecimal();
        }
        private static decimal FromSekToYen(decimal money) // Administrator must add the rate first.
        {
            return money * Yen;
        }
        private static decimal FromYenToSek(decimal money)
        {
            return money / Yen;
        }
        private static decimal FromSekToEur(decimal money)
        {
            return money * Euro;
        }
        private static decimal FromEurToSek(decimal money)
        {
            return money / Euro;
        }
        public static void ShowCurrencyRate()
        {

        }
        public static void Show(User loggedInUser)
        {
            if (loggedInUser is Customer customer)
            {
                Console.Clear();
                
            }
        }
        public static void ConvertMoney(User loggedInUser)  // Customer will do this action. So the exchange rate should be set
        {
            if (loggedInUser is Customer customer)
            {
                Console.Clear();
                Account selectedAccount = ShowSpecificAccount(customer);
               string currency = selectedAccount.Currency;
                switch (GetCurrencyChoice())
                {
                    case 1: // SEK
                        Console.WriteLine("1. SEK");
                        if (currency == "SEK")
                            Console.WriteLine("You have balance in SEK already.");
                        else if (currency == "EUR")
                            Console.WriteLine("It would be " + FromEurToSek(selectedAccount.Balance) + " in SEK.");
                        else if (currency == "YEN")
                            Console.WriteLine("It would be " + Math.Round(FromYenToSek(selectedAccount.Balance), 2) + " in SEK");
                        break;
                    case 2: // EUR
                        Console.WriteLine("2. EUR");
                        if (currency == "EUR")
                            Console.WriteLine("You have balance in EUR already.");
                        else if (currency == "SEK")
                            Console.WriteLine(FromSekToEur(selectedAccount.Balance) + " in Euro");
                        else if (currency == "YEN")
                        {
                            decimal money = FromYenToSek(selectedAccount.Balance);
                            Console.WriteLine(money + "SEK");
                            Console.WriteLine(Math.Round(FromSekToEur(money), 2) + "in Euro");
                        }
                        break;
                    case 3: // YEN
                        Console.WriteLine("3. YEN");
                        if (currency == "YEN")
                            Console.WriteLine("You have balance in YEN already.");
                        else if (currency == "SEK")
                            Console.WriteLine(FromSekToYen(selectedAccount.Balance) + " in yen");
                        else if (currency == "EUR")
                        {
                            decimal money = FromEurToSek(selectedAccount.Balance);
                            Console.WriteLine(Math.Round(FromSekToYen(money), 2) + " in yen");
                        }
                            Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("Sorry, we do not have that choice. You will be directed to the menu.");
                        return;
                        break;
                }
                Transaction transaction = new Transaction
                {
                    TransactionType = "Checked money in different curency",
                    Amount = 0,
                    Timestamp = DateTime.Now
                };
                customer.TransactionHistory.Add(transaction);
                
                Console.WriteLine("Press enter to return to the menu.");
                Console.ReadKey();
            }
            Console.Clear();
        }
        private static Account ShowSpecificAccount(Customer customer)
        {
            Console.WriteLine("Choose an account to view the balance:");
            DisplayUserAccounts(customer);
            int selectedAccountIndex = Validator.GetValidInt("Enter the account number: ", 1, customer.Accounts.Count) - 1;
            Account selectedAccount = customer.Accounts[selectedAccountIndex];
            Console.Clear();
            Console.WriteLine($"Balance for Account {selectedAccount.AccountNumber} ({selectedAccount.AccountName}): {selectedAccount.Balance}({selectedAccount.Currency})");
            return selectedAccount;
        }
        private static void DisplayUserAccounts(Customer customer)
        {
            for (int i = 0; i < customer.Accounts.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Account {customer.Accounts[i].AccountNumber}: {customer.Accounts[i].AccountName} - {customer.Accounts[i].Currency}");
            }
        }
        private static int GetCurrencyChoice()
        {
            Console.WriteLine("Choose currency to view the balance: ");
            string currency1 = "1. SEK";
            string currency2 = "2. EUR";
            string currency3 = "3. YEN";
            Console.WriteLine(currency1 + "\n" + currency2 + "\n" + currency3);
            int currencyChoice = Validator.GetValidInt();
            return currencyChoice;
        }
       
    }
}
