using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class Starting_screen
    {
        public static void StartProgram()
        {
            Console.WriteLine("Welcome to BANK");
            Console.WriteLine("Select you role:");
            int selectRole = Convert.ToInt32(Console.ReadLine());
            switch (selectRole)
            {
                case 1:
                    AdminLogin adminLogin = new AdminLogin();
                    Admin loggedInAdmin = adminLogin.Login();
                    break;
                case 2:
                    CustomerLogin customerLogin = new CustomerLogin();
                    Customer loggedInCustomer = customerLogin.Login();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter '1' for Admin or '2' for Customer.");
                    break;


            }

        }

    }
}
