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
        private static decimal Yen { get; set; } = 14.0M; // ca 14
        private static decimal Euro { get; set; } = 0.089M;  // ca 0.9
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
        public static decimal ConvertMoney(Account selectedAccount, Account targetAccount, decimal amount)  // Customer will do this action. So the exchange rate should be set
        {
            Console.Clear();
            string currency1 = selectedAccount.Currency;
            string currency2 = targetAccount.Currency; 
            decimal money;
            switch (currency1)
            {
                case "SEK":
                    if (currency2 == "SEK")
                        return amount;
                    else if (currency2 == "EUR")
                        return FromSekToEur(amount);
                    else if (currency2 == "YEN")
                        return FromSekToYen(amount);
                    break;
                case "EUR":
                    if (currency2 == "EUR")
                        return amount;
                    else if (currency2 == "SEK")
                        return FromEurToSek(amount);
                    else if (currency2 == "YEN")
                    {
                        money = FromEurToSek(amount);
                        money = Math.Round(FromSekToYen(money), 2);
                        return money;
                    }
                    break;
                case "YEN":
                    if (currency2 == "YEN")
                        return amount;
                    else if (currency2 == "SEK")
                        return Math.Round(FromYenToSek(amount), 2);
                    else if (currency2 == "EUR")
                    {
                        money = FromYenToSek(amount);
                        money = Math.Round(FromSekToEur(money), 2);
                        return money;
                    }
                    break;
                default:
                    Console.WriteLine("Sorry, we do not have that choice. You will be directed to the menu.");
                    return 0;
                    break;
            }
            return 0;
            Console.ReadKey();
        }
       
    }

}
