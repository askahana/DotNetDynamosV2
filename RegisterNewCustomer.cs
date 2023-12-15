using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class RegisterNewCustomer
    {
        public static void RegisterCustomer(LoginSystem loginSystem)
        {
            // Skapa en temporär användare för att lägga till i användarlistan
            Customer newUser = new Customer();
            Console.WriteLine("Welcome to User Registration!");
            // Få användarnamn från användaren
            Console.Write("Enter your username: ");
            string enteredUsername = Console.ReadLine();
            // Kontrollera om användarnamnet redan finns
            if (DataManager.userList.ContainsKey(enteredUsername))
            {
                Console.WriteLine("Username already exists. Please choose a different username.");
                return; // Avsluta metoden om användarnamnet redan finns
            }
            newUser.UserName = enteredUsername;
            // Få förnamn från användaren
            Console.Write("Enter your first name: ");
            newUser.FirstName = Console.ReadLine();
            // Få efternamn från användaren
            Console.Write("Enter your last name: ");
            newUser.LastName = Console.ReadLine();
            // Få lösenord från användaren
            Console.Write("Password must contain:\n6-12 characters\nAt least one capital letter\nAt least one digit\nAt least one symbol\nEnter password: ");
            newUser.PassWord = Console.ReadLine();
            // Låt användaren välja roll
            Console.Write("Choose user role:\n");
            Console.Write("1. Admin\n");
            Console.Write("2. Customer\n");
            newUser.Accounts = new List<Account>();
            newUser.TransactionHistory = new List<Transaction>();
            string roleChoice = Console.ReadLine();

            if (int.TryParse(roleChoice, out int roleNumber))
            {
                switch (roleNumber)
                {
                    case 1:
                        newUser.UserRole = "Admin";
                        break;
                    case 2:
                        newUser.UserRole = "Customer";
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter '1' for Admin or '2' for Customer.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            // Antag att nextAdID är deklarerat någonstans som en statisk variabel i RegisterNewCustomer-klassen
            int nextAdID = 1;
            newUser.IDNumber = nextAdID++;
           
            // Lägg till den nya användaren i userList (dictionary)
            DataManager.userList.Add(newUser.UserName, newUser);

            Console.Clear();

            if (newUser is Admin)
            {
                Console.WriteLine($"Successfully created Admin {newUser.UserName}");
            }
            else if (newUser is Customer)
            {
                Console.WriteLine($"Successfully created Customer {newUser.UserName}");
            }


            // Visa användarinformation

            //if (newUser.UserRole.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            //{
            //    AdminManager adminManager = new AdminManager(loginSystem);
            //    adminManager.Meny(newUser);
            //}
            //else if (newUser.UserRole.Equals("Customer", StringComparison.OrdinalIgnoreCase))
            //{
            //    CustomerManager customerManager = new CustomerManager(loginSystem);
            //    customerManager.Meny(newUser);
            //}
            //else
            //{
            //    Console.WriteLine("Invalid user role. Please choose 'Admin' or 'Customer'.");
            //}
        }

    }

}
