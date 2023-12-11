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
        public static decimal Euro { get; set; } = 0.9M;  // ca 0.9

        public static decimal FromSekToYen(decimal money) // Administrator must add the rate first.
        {
            return money * Yen;
        }
        public static decimal FromYenToSek(decimal money)
        {
            return money / Yen;
        }
        public static decimal FromSekToEur(decimal money)
        {
            return money * Euro;
        }
        public static decimal FromEurToSek(decimal money)
        {
            return money / Euro;
        }
        public static void ConvertMoney(User loggedInUser)  // Customer will do this action. So the exchange rate should be set
        {
            if (loggedInUser is Customer customer)
            {
                Console.WriteLine("Which account?");
                int accountNum = Validator.GetValidInt();
                foreach (Account account in customer.Accounts)
                {
                    if (account.AccountNumber == accountNum && account.Currency == "SEK")
                    {
                        Console.WriteLine("EURO");
                        Console.WriteLine(FromSekToEur(account.Balance));
                        Console.WriteLine("Yen");
                        Console.WriteLine(FromSekToYen(account.Balance));
                    }
                }
            }
            Console.ReadKey();
        }
        public static void InsertRate() // Here administrater can change the exchange rate.
        {
            Console.WriteLine("Insert todays exchange rate.");
            Console.Write("Yen: ");
            Yen = Validator.GetValidDecimal();
            Console.Write("Euro: ");
            Euro = Validator.GetValidDecimal();
        }
    }
}
