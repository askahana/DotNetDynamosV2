namespace DotNetDynamosV2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //LoginSystem loginSystem = new LoginSystem();
            //... andra kodsnuttar ...

            //User loggedInUser = loginSystem.Login(); // Logga in användaren först

            //AdminManager adminManager = new AdminManager(loginSystem);
            //adminManager.Meny(loggedInUser); // Skicka med den inloggade användaren

            //CustomerManager customerManager = new CustomerManager(loginSystem);
            //customerManager.Meny(loggedInUser); // Skicka med den inloggade användaren

            //AccountManagementSystem.Assign();

            //bool loop = true;
            //while (loop)
            //{
            //    Console.WriteLine("Vänligen ange din roll:");
            //    Console.WriteLine("1.Customer");
            //    Console.WriteLine("2. Admin");
            //    Console.WriteLine("3. Exit");
            //    int role = Convert.ToInt32(Console.ReadLine());

            //    switch (role)
            //    {
            //        case 1:
            //            Console.WriteLine("Välkommen som kund!");
            //            AccountManagementSystem.Assign();
            //            break;
            //        case 2:
            //            Console.WriteLine("Välkommen som administratör!");
            //            AccountManagementSystem.AssignAdmin();
            //            break;
            //        case 3:
            //            Environment.Exit(0);
            //            break;
            //        default:
            //            Console.WriteLine("Okänd roll. Vänligen ange antingen 'customer' eller 'admin'.");
            //            break;
            //    }
            //}

            CustomerManager.LogOut();
        }
    }
}