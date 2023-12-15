using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class DataManager
    {
        public static Dictionary<string, User> userList = new Dictionary<string, User>();  // Är det bättre med ID?
        static DataManager()
        {
            Initialize();
        }
        public static void Initialize()
        {
            User cus1 = new Customer
            {
                UserName = "User1",
                IDNumber = 5001,
                FirstName = "Johan",
                LastName = "Johansson",
                PassWord = "Passwords1!",
                Birthday = "1978-01-01",
                Accounts = new List<Account>
                {
                        new Account(50028977, "MainAccount", "SEK", 1234M),
                        new Account(50011265, "SavingAccount", "EUR", 1234M),
                },
                TransactionHistory = new List<Transaction> { },
            };
            User cus2 = new Customer()
            {
                UserName = "User2",
                IDNumber = 5002,
                FirstName = "Anna",
                LastName = "Andersson",
                PassWord = "Password2!",
                Birthday = "1988-01-01",
                Accounts = new List<Account>
                {
                    new Account(12344556, "MainAccount", "SEK", 2345M),
                    new Account(23455678, "SavingAccount", "EUR", 2345M),
                },
                TransactionHistory = new List<Transaction> { },
            };
            User cus3 = new Customer()
            {
                UserName = "User3",
                IDNumber = 5003,
                FirstName = "Alice",
                LastName = "Karlsson",
                PassWord = "Password3!",
                Email = "Akuce@Karlsson.se",
                Birthday = "1998-01-01",
                Accounts = new List<Account>
                {
                },
                TransactionHistory = new List<Transaction> { },
            };
            User ad1 = new Admin()
            {
                UserName = "Admin1",
                IDNumber = 1001,
                FirstName = "Karl",
                LastName = "Karssib",
                PassWord = "Admin!1",
            };
            userList.Add("User1", cus1);
            userList.Add("Admin1", ad1);
            userList.Add("User2", cus2);
            userList.Add("User3", cus3);
        }
    }
}
