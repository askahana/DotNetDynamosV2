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
            Console.WriteLine("1. Log in a as Admin.\n2. Log in as Customer.");
            int selectRole = Convert.ToInt32(Console.ReadLine());
            switch (selectRole)
            {
                case 1:
                    AdminLogin adminLogin = new AdminLogin();
                    adminLogin.Login();
                    break;
                case 2:
                    CustomerLogin customerLogin = new CustomerLogin();
                    customerLogin.Login();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter '1' for Admin or '2' for Customer.");
                    break;


            }

        }

    }
}
