using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class RegisterUser
    { 
        /// <summary>
        /// Metod för att skicka vidare Admin till olika metoder för att reg Admin eller Customer (grundkod hämtad från originalet RegisterCustomer) 
        /// Förbättringsförslag: Lägg till möjlighet att återgå till menyn via att trycka på enter. /N
        /// </summary>
        /// <param name="loggedInAdmin"></param>
        public static void Register(Admin loggedInAdmin) 
        {
            Console.Write("Choose user role:\n");
            Console.Write("1. Admin\n");
            Console.Write("2. Customer\n");
            Console.Write("Press Enter to return to menu.");

            string roleChoice = Console.ReadLine();

            if (int.TryParse(roleChoice, out int roleNumber))
            {
                switch (roleNumber)
                {
                    case 1:
                        RegisterNewAdmin.RegisterAdmin(loggedInAdmin);
                        break;
                    case 2:
                        RegisterNewCustomer.RegisterCustomer(loggedInAdmin);
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
        }

    }
}
