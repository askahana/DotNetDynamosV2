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
                    AdminLogin.
                    break;
                case 2:
                    break;
                default:

                    break;


            }

        }

    }
}
