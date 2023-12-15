using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class TestAska
    {

        public static void GetValidAmount(Account account, decimal money)
        {
            if(money > account.Balance * 5)
            {
                Console.WriteLine("NEJ!!!");
            }
        }

        public static void TransferMoneyBetweenAccount(User loggedInUser) // rename
        {
            Account sourceAccount = null;
            Account targetAccount = null;
            if (loggedInUser is Customer customer)
            {
                ShowBalance.ShowAllAccounts(customer);
                Console.WriteLine("Which account do you want to transfer from?");
                Console.WriteLine("Please press \"enter\" to go to meny.");
                int transferFrom;
                while (true)
                {
                    transferFrom = Validator.GetValidIntOrMenu(customer);
                    sourceAccount = customer.Accounts.Find(a => a.AccountNumber == transferFrom); //Ändra till att söka efter nummer på acc i listan
                    if (sourceAccount == null)
                    {
                        Console.WriteLine("Account number is not correct.");
                        return;
                    }
                    Console.WriteLine("Which account do you want to transfer to? Enter account number:");
                    int transferTo = Validator.GetValidIntOrMenu(customer);
                    targetAccount = customer.Accounts.Find(a => a.AccountNumber == transferTo); //Ändra till att söka efter nummer på acc i listan, ändra i Acc eller utgår från List-metod? /N
                    if(targetAccount == null)
                    {
                        Console.WriteLine("Account number is not correct.");
                        return;
                    }
                    Console.WriteLine("How much money do you want to transfer?");
                    decimal transferAmount = Validator.GetValidDecimal();
                    if (transferAmount < 0 || transferAmount > sourceAccount.Balance)
                    {
                        Console.WriteLine("Invalid transfer amount.");
                        return;
                    }
                    decimal money = Converter.ConvertMoney(sourceAccount, targetAccount, transferAmount);
                    Console.WriteLine($"{transferAmount} {sourceAccount.Currency} blir {money} {targetAccount.Currency}, ok?");
                    sourceAccount.Balance -= transferAmount;
                    targetAccount.Balance += money;

                    Console.WriteLine("SUCESS!");
                    Transaction transaction = new Transaction
                    {
                        TransactionType = "Transfer money",
                        Amount = transferAmount,
                        Timestamp = DateTime.Now
                    };
                    customer.TransactionHistory.Add(transaction);
                    Console.ReadKey();
                }

            }
        }
    }
}
