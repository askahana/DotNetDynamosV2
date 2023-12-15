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
            User newUser = new Customer();
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
            Console.Write("Choose user role (Admin or Customer): ");
            newUser.UserRole = Console.ReadLine();

            // Antag att nextAdID är deklarerat någonstans som en statisk variabel i RegisterNewCustomer-klassen
            int nextAdID = 1;
            newUser.IDNumber = nextAdID++;

            // Lägg till den nya användaren i userList (dictionary)
            DataManager.userList.Add(newUser.UserName, newUser);

            // Visa användarinformation

            if (newUser.UserRole.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                AdminManager adminManager = new AdminManager(loginSystem);
                adminManager.Meny(newUser);
            }
            else if (newUser.UserRole.Equals("Customer", StringComparison.OrdinalIgnoreCase))
            {
                CustomerManager customerManager = new CustomerManager(loginSystem);
                customerManager.Meny(newUser);
            }
            else
            {
                Console.WriteLine("Invalid user role. Please choose 'Admin' or 'Customer'.");
            }
        }
    }

}
