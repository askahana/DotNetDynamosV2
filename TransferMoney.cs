using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class TransferMoney
    {
        /// <summary>
        /// Nathalee:
        /// Metod för att föra över pengar till andra egna konton. 
        /// Ändra så det inte är accountnumber som används i sökfunktionen, se över om det är smidigast att lägga in en parameter i IAccounts
        /// eller att använda metoder i list för detta.
        /// Utökade failsafes för att säkerställa att det är rätt mängd pengar som förs över.
        /// Ny metod i annan klass för att lagra informationen som skett i denna klass för att kunna komma åt historik.
        /// </summary>
        /// <param name="loggedInUser"></param>
        public static void TransferMoneyBetweenAccount(Customer loggedInCustomer) // Ändrat till Customer.
        {
            Account sourceAccount = null;
            Account targetAccount = null;

            Console.Clear();
            Console.WriteLine("Here are your accounts:\n");
            foreach (Account account in loggedInCustomer.Accounts)
            {
                Console.WriteLine($"{account.SortOrder}.");
                Console.WriteLine($"Account name: {account.AccountName}");
                Console.WriteLine($"Account number:{account.AccountNumber}");
                Console.WriteLine($"Currency:{account.Currency}");
                Console.WriteLine($"Balance:{account.Balance}\n");
            }

            while (true)
            {
                Console.WriteLine("Which account do you want to transfer from?");
                Console.WriteLine("Please press \"enter\" to go to meny.");
                int transferFromAcc;

                var backkey = Console.ReadKey(intercept: true); // intercept = true prevents the entered key from being displayed

                if (backkey.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    CustomerManager.Menu(loggedInCustomer);
                    return;
                }
                // If the entered key is not Enter, proceed to check for integer input
                else if (!int.TryParse(backkey.KeyChar.ToString(), out transferFromAcc))
                {
                    Console.WriteLine("Invalid input. Please enter a number corresponding to the account you wish to transfer from or press 'Enter' to return to the Menu.");
                    continue;
                }

                foreach (Account account in loggedInCustomer.Accounts)
                {
                    while (transferFromAcc == account.SortOrder)
                    {
                        Console.Clear();
                        Console.WriteLine($"You have chosen to transfer from {account.AccountName}.\n");
                        Console.WriteLine("Which account would you like to transfer from?");
                        Console.WriteLine("Press Enter return to Account view.");
                        int transferToAcc;
                        if (backkey.Key == ConsoleKey.Enter)
                        {
                            Console.Clear();
                            break;
                        }
                        else if (!int.TryParse(backkey.KeyChar.ToString(), out transferToAcc))
                        {
                            Console.WriteLine("Invalid input. Please enter a number corresponding to the account you wish to transfer from or press 'Enter' to return to Account view.");
                            continue;
                        }

                        targetAccount = loggedInCustomer.Accounts.Find(a => a.AccountNumber == transferToAcc); //Ändra till att söka efter nummer på acc i listan, ändra i Acc eller utgår från List-metod? /N

                        sourceAccount = loggedInCustomer.Accounts.Find(a => a.AccountNumber == transferFromAcc); //Ändra till att söka efter nummer på acc i listan
                        Console.WriteLine("How much money do you want to transfer?");
                        decimal transferAmount; // Ensure valid input
                        try
                        {
                            transferAmount = Convert.ToDecimal(Console.ReadLine());
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Incorrect input, please enter a numeric value.");
                            continue;
                        }
                        if (transferAmount < 0 || transferAmount > sourceAccount.Balance)
                        {
                            Console.WriteLine("Invalid transfer amount.");
                            return;
                        }
                        decimal money = Converter.ConvertMoney(sourceAccount, targetAccount, transferAmount);
                        Console.WriteLine($"{transferAmount} {sourceAccount.Currency} blir {money} {targetAccount.Currency}, okidoki?");
                        sourceAccount.Balance -= transferAmount;
                        targetAccount.Balance += money;   // Ändrade här så att konverterade amount kommer att sättas in
                        Transaction transaction = new Transaction
                        {
                            TransactionType = "Transfer money",
                            Amount = transferAmount,
                            Timestamp = DateTime.Now
                        };
                        loggedInCustomer.TransactionHistory.Add(transaction);

                        //Lägg till information till användaren om trasaktionen. /N
                        //Lägg till metod för att lagra informationen i historik. /N
                        Console.WriteLine("Kundmeddelande");
                        Console.ReadKey();
                        Console.Clear();
                        CustomerManager.Menu(loggedInCustomer);
                    }

                }

            }

        }


    }
        /// <summary>
        /// Nathalee:
        /// Metod för att ta ut pengar från egna konton. 
        /// Förbättringsförslag från mig själv inkluderar: hitta ett smidigt sätt att läsa in användaren så att det 
        /// enkelt går att skicka tillbaka hen till menyn. 
        /// Ändra så det inte är accountnumber som används i sökfunktionen, se över om det är smidigast att lägga in en parameter i IAccounts
        /// eller att använda metoder i list för detta.
        /// Utökade failsafes för att säkerställa att det är rätt mängd pengar som tas ut.
        /// Lösenord när man tar ut?
        /// Ny metod i annan klass för att lagra informationen som skett i denna klass för att kunna komma åt historik.
        /// </summary>
        /// <param name="loggedInUser"></param>
        //    public static void Withdraw(Customer loggedInCustomer)
        //    {
        //        Account sourceAccount = null;
        //        Account targetAccount = null;

        //        foreach (Account account in customer.Accounts)
        //        {

        //            Console.WriteLine($"Account name: {account.AccountName}");
        //            Console.WriteLine($"Account number:{account.AccountNumber}");
        //            Console.WriteLine($"Currency:{account.Currency}");
        //            Console.WriteLine($"Balance:{account.Balance}");
        //        }
        //        Console.WriteLine("Which account do you want to withdraw from?");
        //        Console.WriteLine("Please press \"enter\" to go to meny.");
        //        string intChoice = Console.ReadLine();
        //        while (true)
        //        {
        //            int withdrawFrom;
        //            string chooseWithdrawFrom = Console.ReadLine();
        //            if (string.IsNullOrEmpty(chooseWithdrawFrom)) //Om användaren trycker på enter återgår hen till menyn./N
        //            {
        //                Console.Clear();
        //                //Meny(LoggedIn); 
        //                //Koppling från användaren krävs för att kunna återgå till menyn. /N
        //                return;
        //            }

        //            try
        //            {
        //                withdrawFrom = Convert.ToInt32(chooseWithdrawFrom);
        //            }
        //            catch (FormatException)
        //            {
        //                Console.WriteLine("Incorrect input, please enter a number or press ENTER to return to Menu.");
        //                continue;
        //            }

        //            sourceAccount = customer.Accounts.Find(a => a.AccountNumber == withdrawFrom); //Ändra senare till att söka efter nummer på acc i listan
        //            Console.WriteLine("What amount would you like to withdraw?");
        //            decimal withdrawAmount; // Ensure valid input
        //            try
        //            {
        //                withdrawAmount = Convert.ToDecimal(Console.ReadLine());
        //            }
        //            catch (FormatException)
        //            {
        //                Console.WriteLine("Incorrect input, please enter a numeric value.");
        //                continue;
        //            }
        //            if (withdrawAmount < 0 || withdrawAmount > sourceAccount.Balance)
        //            {
        //                Console.WriteLine("Invalid transfer amount.");
        //                return;
        //            }
        //            sourceAccount.Balance -= withdrawAmount;

        //            //Lägg till info om vad som har tagits ut. 
        //            //Lägg till metod för att lagra informationen i historik. 

        //            //Console.Clear följt av logik för att returnera användaren till menyn.  /N

        //        }


        //    }
        //    /// <summary>
        //    /// Nathalee:
        //    /// Metod för att sätta in pengar på egna konton. 
        //    /// Förbättringsförslag från mig själv inkluderar: 
        //    /// !Hitta ett smidigt sätt att läsa in användaren så att det 
        //    /// enkelt går att skicka tillbaka hen till menyn. 
        //    /// Ändra så det inte är accountnumber som används i sökfunktionen, se över om det är smidigast att lägga in en parameter i IAccounts
        //    /// eller att använda metoder i list för detta.
        //    /// Utökade failsafes för att säkerställa att det är rätt mängd pengar som förs ut, kanske sätta fasta summor? (Tänker tex om man ska utgå från sedlar).
        //    /// Tror det går att göra intressanta saker framöver där. 
        //    /// Ny metod i annan klass för att lagra informationen som skett i denna klass för att kunna komma åt historik.
        //    /// </summary>
        //    /// <param name="loggedInUser"></param>
        //    public static void Deposit(Customer loggedInCustomer)
        //    {
        //        Account sourceAccount = null;
        //        Account targetAccount = null;
        //        if (loggedInCustomer is Customer customer)
        //        {
        //            foreach (Account account in customer.Accounts)
        //            {

        //                Console.WriteLine($"Account name: {account.AccountName}");
        //                Console.WriteLine($"Account number:{account.AccountNumber}");
        //                Console.WriteLine($"Currency:{account.Currency}");
        //                Console.WriteLine($"Balance:{account.Balance}");
        //            }
        //            Console.WriteLine("Which account do you want to deposit to?");
        //            Console.WriteLine("Please press \"enter\" to go to meny.");
        //            string intChoice = Console.ReadLine();
        //            while (true)
        //            {
        //                int depositTo;
        //                string chooseDepositTo = Console.ReadLine();
        //                if (string.IsNullOrEmpty(chooseDepositTo)) //Om användaren trycker på enter återgår hen till menyn./N
        //                {
        //                    Console.Clear();
        //                    //Meny(LoggedIn); 
        //                    //Koppling från användaren krävs för att kunna återgå till menyn. /N
        //                    return;
        //                }

        //                try
        //                {
        //                    depositTo = Convert.ToInt32(chooseDepositTo);
        //                }
        //                catch (FormatException)
        //                {
        //                    Console.WriteLine("Incorrect input, please enter a number or press ENTER to return to Menu.");
        //                    continue;
        //                }

        //                sourceAccount = customer.Accounts.Find(a => a.AccountNumber == depositTo); //Ändra senare till att söka efter nummer på acc i listan
        //                Console.WriteLine("What amount would you like to deposit?");
        //                decimal depositAmount; // Ensure valid input
        //                try
        //                {
        //                    depositAmount = Convert.ToDecimal(Console.ReadLine());
        //                }
        //                catch (FormatException)
        //                {
        //                    Console.WriteLine("Incorrect input, please enter a numeric value.");
        //                    continue;
        //                }
        //                if (depositAmount < 0 || depositAmount > sourceAccount.Balance)
        //                {
        //                    Console.WriteLine("Invalid transfer amount.");
        //                    return;
        //                }
        //                sourceAccount.Balance += depositAmount;

        //                //Lägg till info om vad som har tagits ut. 
        //                //Lägg till metod för att lagra informationen i historik. 

        //                //Console.Clear följt av logik för att returnera användaren till menyn.  /N
        //            }
        //        }
        //    }
        //    /// <summary>
        //    /// Nathalee:
        //    /// Metod för att föra över pengar till andra egna konton. 
        //    /// Förbättringsförslag från mig själv inkluderar: hitta ett smidigt sätt att läsa in användaren så att det 
        //    /// enkelt går att skicka tillbaka hen till menyn. 
        //    /// Ändra så det inte är accountnumber som används i sökfunktionen för egna konton, se över om det är smidigast att lägga in en parameter i IAccounts
        //    /// eller att använda metoder i list för detta.
        //    /// Se över hur vi ska koppla till dictionary för att sökfunktionen ska komma åt andra användare. 
        //    /// Skapa logik för koppling till andra användare.
        //    /// Utökade failsafes för att säkerställa att det är rätt mängd pengar som förs över samt att de förs över till rätt person.
        //    /// Ny metod i annan klass för att lagra informationen som skett i denna klass för att kunna komma åt historik.
        //    /// Valuta? 
        //    /// </summary>
        //    /// <param name="loggedInUser"></param>
        //    public static void TransferMoeneyToOthers(Customer loggedInCustomer)  // rename
        //    {
        //        Account sourceAccount = null;
        //        Account targetAccount = null;
        //        if (loggedInCustomer is Customer customer)
        //        {
        //            foreach (Account account in customer.Accounts)
        //            {

        //                Console.WriteLine($"Account name: {account.AccountName}");
        //                Console.WriteLine($"Account number:{account.AccountNumber}");
        //                Console.WriteLine($"Currency:{account.Currency}");
        //                Console.WriteLine($"Balance:{account.Balance}");
        //            }
        //            Console.WriteLine("Which account do you want to transfer from?");
        //            Console.WriteLine("Please press \"enter\" to go to meny.");
        //            string intChoice = Console.ReadLine();
        //            while (true)
        //            {
        //                int transferFrom;
        //                string chooseTransferFrom = Console.ReadLine();
        //                if (string.IsNullOrEmpty(chooseTransferFrom)) //Om användaren trycker på enter återgår hen till menyn./N
        //                {
        //                    Console.Clear();
        //                    //Meny(LoggedIn); 
        //                    //Koppling från användaren krävs för att kunna återgå till menyn. I nuläget hämtar vi information från användaren som lagrats
        //                    //i LoginSystem, men den kopplingen bryts sedan, för att komma åt menyn här skulle vi behöva skapa ett objekt CustomerManager klassen, och det 
        //                    //finns risk att programmet blir förvirrat om vi gör på det sättet. /N
        //                    return;
        //                }

        //                try
        //                {
        //                    transferFrom = Convert.ToInt32(chooseTransferFrom);
        //                }
        //                catch (FormatException)
        //                {
        //                    Console.WriteLine("Incorrect input, please enter a number or press ENTER to return to Menu.");
        //                    continue;
        //                }
        //                Console.WriteLine("Which account do you want to transfer to? Enter the account number of the account held by the other person:");
        //                int transferTo;
        //                string chooseTransferTo = Console.ReadLine();
        //                if (string.IsNullOrEmpty(chooseTransferTo)) //Om användaren trycker på enter återgår hen till menyn./N
        //                {
        //                    Console.Clear();
        //                    //Meny(LoggedIn); //Koppling från användaren krävs för att kunna återgå till menyn./N
        //                    return;
        //                }

        //                //Logik för att söka efter användarkonton i dictionary krävs. 
        //                //Se över åtkomst till dictionary. 
        //                //Lägg till failsafe med meddelande om vilken användare det ska skickas till (För och efternam samt accnr)
        //                //och vilket amount som blivit tilldelat för att sändas, kräv godkännande av användaren samt lösenord igen. 
        //                //Lägg till val av valuta? 

        //                //try
        //                //{
        //                //    transferTo = Convert.ToInt32(chooseTransferTo);
        //                //}
        //                //catch (FormatException)
        //                //{
        //                //    Console.WriteLine("Incorrect input, please enter a number or press ENTER to return to Menu.");
        //                //    continue;
        //                //}
        //                //targetAccount = customer.Accounts.Find(a => a.AccountNumber == transferTo); //Ändra till att söka efter nummer på acc i listan, ändra i Acc eller utgår från List-metod? /N

        //                sourceAccount = customer.Accounts.Find(a => a.AccountNumber == transferFrom); //Ändra till att söka efter nummer på acc i listan
        //                Console.WriteLine("How much money do you want to transfer?");
        //                decimal transferAmount; // Ensure valid input
        //                try
        //                {
        //                    transferAmount = Convert.ToDecimal(Console.ReadLine());
        //                }
        //                catch (FormatException)
        //                {
        //                    Console.WriteLine("Incorrect input, please enter a numeric value.");
        //                    continue;
        //                }
        //                if (transferAmount < 0 || transferAmount > sourceAccount.Balance)
        //                {
        //                    Console.WriteLine("Invalid transfer amount.");
        //                    return;
        //                }
        //                sourceAccount.Balance -= transferAmount;
        //                targetAccount.Balance += transferAmount;
        //                //Lägg till information till användaren om trasaktionen. /N
        //                //Lägg till metod för att lagra informationen i historik. /N

        //                //Console.Clear följt av logik för att returnera användaren till menyn.  /N


        //            }

        //        }


        //    }
    }
}
