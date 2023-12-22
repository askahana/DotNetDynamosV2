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
        public static void TransferMoneyBetweenAccount(Customer loggedInCustomer) 
        {
            while (true)
            {
                Console.Clear();
                ShowAllAcc(loggedInCustomer);

                Console.WriteLine("Enter the number of the account you want to transfer from:");
                if (!int.TryParse(Console.ReadLine(), out int transferFromOrder))
                {
                    Console.WriteLine("Invalid input. Please enter a valid account number.");
                    continue;
                }

                Account sourceAccount = loggedInCustomer.Accounts.Find(a => a.SortOrder == transferFromOrder);

                if (sourceAccount == null)
                {
                    Console.WriteLine("Source account not found.");
                    continue;
                }

                Console.WriteLine("Enter the amount to transfer:");
                if (!decimal.TryParse(Console.ReadLine(), out decimal transferAmount) || transferAmount <= 0 || transferAmount > sourceAccount.Balance)
                {
                    Console.WriteLine("Invalid transfer amount.");
                    continue;
                }

                Console.WriteLine("Enter the account number you want to transfer to:");
                if (!int.TryParse(Console.ReadLine(), out int transferToOrder))
                {
                    Console.WriteLine("Invalid input. Please enter a valid account number.");
                    continue;
                }

                Account targetAccount = loggedInCustomer.Accounts.Find(a => a.SortOrder == transferToOrder);

                if (targetAccount == null)
                {
                    Console.WriteLine("Target account not found.");
                    continue;
                }

                decimal money = Converter.ConvertMoney(sourceAccount, targetAccount, transferAmount);

                Console.WriteLine($"{transferAmount} {sourceAccount.Currency} will become {money} {targetAccount.Currency}, proceed?\n\n Press Enter to return to account choice.");
                Console.WriteLine("[1]. Yes");
                Console.WriteLine("[2]. No");

                if (int.TryParse(Console.ReadLine(), out int confirm) && confirm == 1)
                {
                    sourceAccount.Balance -= transferAmount;
                    targetAccount.Balance += money;

                    Transaction transaction = new Transaction
                    {
                        TransactionType = "Transfer money",
                        Amount = transferAmount,
                        Timestamp = DateTime.Now
                    };
                    loggedInCustomer.TransactionHistory.Add(transaction);

                    Console.WriteLine("Transaction successful."); //Mer info=
                }
                else
                {
                    Console.WriteLine("Transaction cancelled.");
                }

                Console.WriteLine("Press Enter to return to account choice or any other key to exit.");
                if (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    break; // Exit the loop if any key other than Enter is pressed
                }
            }

            Console.Clear();
            CustomerManager.Menu(loggedInCustomer);
        }



        //Account targetAccount = null;

        //Console.Clear();
        //Console.WriteLine("Here are your accounts:\n");
        //foreach (Account account in loggedInCustomer.Accounts)
        //{
        //    Console.WriteLine($"{account.SortOrder}.");
        //    Console.WriteLine($"Account name: {account.AccountName}");
        //    Console.WriteLine($"Account number:{account.AccountNumber}");
        //    Console.WriteLine($"Currency:{account.Currency}");
        //    Console.WriteLine($"Balance:{account.Balance}\n");
        //}

        //while (true)
        //{
        //    Console.WriteLine("Which account do you want to transfer from?");
        //    Console.WriteLine("Please press \"enter\" to go to meny.");
        //    string transferFromAcc = Console.ReadLine();

        //    if (string.IsNullOrEmpty(transferFromAcc))
        //    {
        //        Console.Clear();
        //        CustomerManager.Menu(loggedInCustomer);
        //        return;
        //    }

        //    if (!int.TryParse(transferFromAcc, out int transferFromOrder))
        //    {
        //        Console.WriteLine("Invalid input. Please enter a valid account number.");
        //        return;
        //    }

        //    //var backkey = Console.ReadKey(intercept: true); // intercept = true prevents the entered key from being displayed

        //    //if (backkey.Key == ConsoleKey.Enter)
        //    //{
        //    //    Console.Clear();
        //    //    CustomerManager.Menu(loggedInCustomer);
        //    //    return;
        //    //}
        //    // If the entered key is not Enter, proceed to check for integer input
        //    //else if (!int.TryParse(backkey.KeyChar.ToString(), out transferFromAcc))
        //    //{
        //    //    Console.WriteLine("Invalid input. Please enter a number corresponding to the account you wish to transfer from or press 'Enter' to return to the Menu.");
        //    //    continue;
        //    //}
        //    //if (!int.TryParse(transferFromAcc, out int transferFromOrder))
        //    //{
        //    //    Console.WriteLine("Invalid input. Please enter a valid account number.");
        //    //    return;
        //    //}

        //    Account sourceAccount = loggedInCustomer.Accounts.Find(a => a.SortOrder == transferFromOrder);
        //    if (sourceAccount == null)
        //    {
        //        Console.WriteLine("Account not found.");
        //        return;
        //    }



        //    while (transferFromAcc == account.SortOrder)
        //    {
        //        Console.Clear();
        //        Console.WriteLine($"You have chosen to transfer from {account.AccountName}.\n");
        //        Console.WriteLine("Which account would you like to transfer from?");
        //        Console.WriteLine("Press Enter return to Account view.");
        //        int transferToAcc;
        //        if (backkey.Key == ConsoleKey.Enter)
        //        {
        //            Console.Clear();
        //            break;
        //        }
        //        else if (!int.TryParse(backkey.KeyChar.ToString(), out transferToAcc))
        //        {
        //            Console.WriteLine("Invalid input. Please enter a number corresponding to the account you wish to transfer from or press 'Enter' to return to Account view.");
        //            continue;
        //        }

        //        targetAccount = loggedInCustomer.Accounts.Find(a => a.AccountNumber == transferToAcc); //Ändra till att söka efter nummer på Acc i listan, ändra i Acc eller utgår från List-metod? /N

        //        sourceAccount = loggedInCustomer.Accounts.Find(a => a.AccountNumber == transferFromAcc); //Ändra till att söka efter nummer på acc i listan
        //        Console.WriteLine("How much money do you want to transfer?");
        //        decimal transferAmount; // Ensure valid input
        //        try
        //        {
        //            transferAmount = Convert.ToDecimal(Console.ReadLine());
        //        }
        //        catch (FormatException)
        //        {
        //            Console.WriteLine("Incorrect input, please enter a numeric value.");
        //            continue;
        //        }
        //        if (transferAmount < 0 || transferAmount > sourceAccount.Balance)
        //        {
        //            Console.WriteLine("Invalid transfer amount.");
        //            return;
        //        }
        //        decimal money = Converter.ConvertMoney(sourceAccount, targetAccount, transferAmount);
        //        Console.WriteLine($"{transferAmount} {sourceAccount.Currency} blir {money} {targetAccount.Currency}, okidoki?");
        //        sourceAccount.Balance -= transferAmount;
        //        targetAccount.Balance += money;   // Ändrade här så att konverterade amount kommer att sättas in
        //        Transaction transaction = new Transaction
        //        {
        //            TransactionType = "Transfer money",
        //            Amount = transferAmount,
        //            Timestamp = DateTime.Now
        //        };
        //        loggedInCustomer.TransactionHistory.Add(transaction);

        //        //Lägg till information till användaren om trasaktionen. /N
        //        //Lägg till metod för att lagra informationen i historik. /N
        //        Console.WriteLine("Kundmeddelande");
        //        Console.ReadKey();
        //        Console.Clear();
        //        CustomerManager.Menu(loggedInCustomer);






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
        public static void Withdraw(Customer loggedInCustomer)
        {
            loggedInCustomer.PasswordAttempts = 1;
            int maxPasswordAttempts = 3;
            while (loggedInCustomer.PasswordAttempts < maxPasswordAttempts)
            {
                Console.Clear();
                ShowAllAcc(loggedInCustomer);

                Console.WriteLine("Enter the number of the account you want to withdraw from:");
                if (!int.TryParse(Console.ReadLine(), out int withdrawFromOrder))
                {
                    Console.WriteLine("Invalid input. Please enter a valid account number.");
                    continue;
                }

                Account sourceAccount = loggedInCustomer.Accounts.Find(a => a.SortOrder == withdrawFromOrder);

                if (sourceAccount == null)
                {
                    Console.WriteLine("Source account not found.");
                    continue;
                }

                Console.WriteLine("Enter the amount to withdraw:");
                if (!decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount) || withdrawAmount <= 0 || withdrawAmount > sourceAccount.Balance)
                {
                    Console.WriteLine("Invalid withdraw amount.");
                    continue;
                }


                if (int.TryParse(Console.ReadLine(), out int confirm) && confirm == 1)
                {

                    Console.WriteLine("Enter Password to confirm withdrawal:");
                    string enteredPassword = Validator.GetHiddenInput();
                    if (CustomerLogin.ValidateCustomerPassword(loggedInCustomer.UserName, enteredPassword))
                    {
                        sourceAccount.Balance -= withdrawAmount;

                        Transaction transaction = new Transaction
                        {
                            TransactionType = "Withdraw money",
                            Amount = withdrawAmount,
                            Timestamp = DateTime.Now
                        };
                        loggedInCustomer.TransactionHistory.Add(transaction);

                        Console.WriteLine("Transaction successful.");
                    }
                    else
                    {
                        Console.WriteLine($"Incorrect password. You have {maxPasswordAttempts - loggedInCustomer.PasswordAttempts} attempts remaining."); //Inte klart
                    }

                }
                else
                {
                    Console.WriteLine("Transaction cancelled.");
                }


                Console.WriteLine("Press Enter to return to account choice or any other key to exit.");
                if (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    break; // Exit the loop if any key other than Enter is pressed
                }
            }

            Console.Clear();
            CustomerManager.Menu(loggedInCustomer);


        }
        public static void ShowAllAcc(Customer loggedInCustomer)
        {
            Console.WriteLine("Here are your accounts:\n");

            foreach (Account account in loggedInCustomer.Accounts)
            {
                Console.WriteLine($"{account.SortOrder}.");
                Console.WriteLine($"Account name: {account.AccountName}");
                Console.WriteLine($"Account number: {account.AccountNumber}");
                Console.WriteLine($"Currency: {account.Currency}");
                Console.WriteLine($"Balance: {account.Balance}\n");
            }
        }
        private void IncrementPasswordAttempts(Customer loggedInCustomer)
        {
            if (loggedInCustomer.PasswordAttempts <= 2)
            {
                loggedInCustomer.PasswordAttempts ++;
            }
            else if (loggedInCustomer.PasswordAttempts >= 3)
            {
                LockOutUser(loggedInCustomer);
            }
        }

        private void LockOutUser(Customer loggedInCustomer)
        {
            CustomerLogin.loginAttemptsCount[loggedInCustomer.UserName] = 3;
            Console.WriteLine($"User {loggedInCustomer.UserName} is locked out. Please contact support.");
        }
        /// <summary>
        /// Nathalee:
        /// Metod för att sätta in pengar på egna konton. 
        /// Förbättringsförslag från mig själv inkluderar: 
        /// !Hitta ett smidigt sätt att läsa in användaren så att det 
        /// enkelt går att skicka tillbaka hen till menyn. 
        /// Ändra så det inte är accountnumber som används i sökfunktionen, se över om det är smidigast att lägga in en parameter i IAccounts
        /// eller att använda metoder i list för detta.
        /// Utökade failsafes för att säkerställa att det är rätt mängd pengar som förs ut, kanske sätta fasta summor? (Tänker tex om man ska utgå från sedlar).
        /// Tror det går att göra intressanta saker framöver där. 
        /// Ny metod i annan klass för att lagra informationen som skett i denna klass för att kunna komma åt historik.
        /// </summary>
        /// <param name="loggedInUser"></param>
        public static void Deposit(Customer loggedInCustomer)
        {
            while (true)
            {
                Console.Clear();
                ShowAllAcc(loggedInCustomer);

                Console.WriteLine("Enter the number of the account you want to deposit to:");
                if (!int.TryParse(Console.ReadLine(), out int transferFromOrder))
                {
                    Console.WriteLine("Invalid input. Please enter a valid account number.");
                    continue;
                }

                Account depositTo = loggedInCustomer.Accounts.Find(a => a.SortOrder == transferFromOrder);

                if (depositTo == null)
                {
                    Console.WriteLine("Source account not found.");
                    continue;
                }

                Console.WriteLine("Enter the amount to deposit:");
                if (!decimal.TryParse(Console.ReadLine(), out decimal transferAmount) || transferAmount <= 0 || transferAmount > depositTo.Balance)
                {
                    Console.WriteLine("Invalid transfer amount.");
                    continue;
                }

                //decimal money = Converter.ConvertMoney(depositTo, targetAccount, transferAmount); //Behöver ny metod i convert

                //Console.WriteLine($"{transferAmount} {depositTo.Currency} will become {money} {targetAccount.Currency}, proceed?\n\n Press Enter to return to account choice.");
                //Console.WriteLine("[1]. Yes");
                //Console.WriteLine("[2]. No");

                if (int.TryParse(Console.ReadLine(), out int confirm) && confirm == 1)
                {
                    depositTo.Balance += transferAmount;

                    Transaction transaction = new Transaction
                    {
                        TransactionType = "Deposit money",
                        Amount = transferAmount,
                        Timestamp = DateTime.Now
                    };
                    loggedInCustomer.TransactionHistory.Add(transaction);

                    Console.WriteLine("Transaction successful."); //Mer info=
                }
                else
                {
                    Console.WriteLine("Transaction cancelled.");
                }

                Console.WriteLine("Press Enter to return to account choice or any other key to exit.");
                if (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    break; // Exit the loop if any key other than Enter is pressed
                }
            }

            Console.Clear();
            CustomerManager.Menu(loggedInCustomer);

                
            
        }
        /// <summary>
        /// Nathalee:
        /// Metod för att föra över pengar till andra egna konton.
        /// Förbättringsförslag från mig själv inkluderar: hitta ett smidigt sätt att läsa in användaren så att det 
        /// enkelt går att skicka tillbaka hen till menyn. 
        /// Ändra så det inte är accountnumber som används i sökfunktionen för egna konton, se över om det är smidigast att lägga in en parameter i IAccounts
        /// eller att använda metoder i list för detta.
        /// Se över hur vi ska koppla till dictionary för att sökfunktionen ska komma åt andra användare. 
        /// Skapa logik för koppling till andra användare.
        /// Utökade failsafes för att säkerställa att det är rätt mängd pengar som förs över samt att de förs över till rätt person.
        /// Ny metod i annan klass för att lagra informationen som skett i denna klass för att kunna komma åt historik.
        /// Valuta?
        /// </summary>
        /// <param name = "loggedInUser" ></ param >
        public static void TransferMoeneyToOthers(Customer loggedInCustomer)  // rename
        {
            while (true)
            {
                Console.Clear();
                ShowAllAcc(loggedInCustomer);

                Console.WriteLine("Enter the number of the account you want to transfer from:");
                if (!int.TryParse(Console.ReadLine(), out int transferFromOrder))
                {
                    Console.WriteLine("Invalid input. Please enter a valid account number.");
                    continue;
                }

                Account sourceAccount = loggedInCustomer.Accounts.Find(a => a.SortOrder == transferFromOrder);

                if (sourceAccount == null)
                {
                    Console.WriteLine("Source account not found.");
                    continue;
                }

                Console.WriteLine("Enter the amount to transfer:");
                if (!decimal.TryParse(Console.ReadLine(), out decimal transferAmount) || transferAmount <= 0 || transferAmount > sourceAccount.Balance)
                {
                    Console.WriteLine("Invalid transfer amount.");
                    continue;
                }
                Account targetAccount;

                Console.WriteLine("Enter the account number of the person you would like to transfer to:");


                if (!int.TryParse(Console.ReadLine(), out int transferToAccountNr))
                {
                    Console.WriteLine("Invalid input. Please enter a valid account number.");
                    continue;
                }

                bool targetAccountFound = FindAndTransfer(loggedInCustomer, transferFromOrder, transferAmount, transferToAccountNr);

                if (!targetAccountFound)
                {
                    Console.WriteLine("Target account not found.");
                    continue;
                }

                Console.WriteLine("Press Enter to return to account choice or any other key to exit.");
                if (Console.ReadKey().Key != ConsoleKey.Enter)
                {
                    break; // Exit the loop if any key other than Enter is pressed
                }
            }

            Console.Clear();
            CustomerManager.Menu(loggedInCustomer);


        }
        public static bool FindAndTransfer(Customer loggedInCustomer, int transferFromOrder, decimal transferAmount, int transferToAccountNr)
        {
            foreach (KeyValuePair<string, Customer> user in DataManager.customerList)
            {
                if (user.Value.Accounts.Any(acc => acc.AccountNumber == transferToAccountNr))
                {
                    Customer targetCustomer = user.Value;
                    Account targetAccount = targetCustomer.Accounts.Find(a => a.AccountNumber == transferToAccountNr);

                    if (targetAccount != null)
                    {
                        // Assuming your transfer logic here...
                        Account sourceAccount = loggedInCustomer.Accounts.Find(a => a.SortOrder == transferFromOrder);
                        if (sourceAccount != null && sourceAccount.Balance >= transferAmount)
                        {
                            decimal money = Converter.ConvertMoney(sourceAccount, targetAccount, transferAmount);
                            sourceAccount.Balance -= transferAmount;
                            targetAccount.Balance += money;

                            Transaction transaction = new Transaction
                            {
                                TransactionType = "Transfer money",
                                Amount = transferAmount,
                                Timestamp = DateTime.Now
                            };
                            loggedInCustomer.TransactionHistory.Add(transaction);

                            Console.WriteLine("Transaction successful.");
                            return true; // Found and completed transfer
                        }
                    }
                }
            }

            return false; // Target account not found

        }
    }

}
