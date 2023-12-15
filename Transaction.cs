using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class Transaction
    {
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime Timestamp { get; set; }        
        //Transaction transaction = new Transaction   // Lägga till den här där du vill ha transaction.
        //{
        //    TransactionType = "Checked money in different curency",
        //    Amount = 0,
        //    Timestamp = DateTime.Now
        //};
        //customer.TransactionHistory.Add(transaction);

        public static void ShowTransactionHistory(User loggedInUser)
        {
            Console.Clear();
            if (loggedInUser is Customer customer)
            {
                Console.WriteLine("Show history");
                foreach (Transaction transaction in customer.TransactionHistory)
                {
                    Console.WriteLine($"Time: {transaction.Timestamp}   Type: {transaction.TransactionType}   Transaction: {transaction.Amount} ");
                }
            }
            Console.WriteLine("Press enter to return to the menu.");
            Console.ReadKey();
        }
    }
}
