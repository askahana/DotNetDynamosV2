using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class AccountManagementSystem
    {
        public static void Assign()
        {
            LoginSystem log = new LoginSystem();
            User user = log.Login();
            CustomerManager cus = new CustomerManager();
            AdminManager ad = new AdminManager(log);

            if (user is Customer)
            {
                cus.Meny(user);
            }
            else if (user is Admin)
            {
                ad.Meny(user);
            }
            else
            {
                Environment.Exit(0);
            }

            // Efter att användaren har loggat in och du vet dess roll, kan du anropa RegisterCustomer här
            //RegisterNewCustomer.RegisterCustomer(log);
        }
        //public static void Assign2()
        //{
        //    Console.WriteLine("Choose customer or Admin."
        //        + "\n[1. Customer]"
        //        + "\n[2. Admin]");
        //    bool isGoing = true;
        //    while (isGoing)
        //    {
        //        int choice = Validator.GetValidInt();
        //        switch (choice)
        //        {
        //            case 1:
        //                UserManager.Menu();
        //                break;
        //            case 2:
        //                AdminManager.Menu();
        //                break;
        //            case 3:
        //                Console.Clear();
        //                Console.WriteLine("Welcomback");
        //                Console.ReadKey();
        //                isGoing = false;
        //                break;
        //            default:
        //                Console.WriteLine("Insert 1 or 2.");
        //                break;
        //        }
        //    }
        //}
    }
}

