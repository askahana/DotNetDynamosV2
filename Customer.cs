using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class Customer : ICustomer
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IDNumber { get; set; }
        public string UserRole { get; set; }
        public string Email { get; set; }
        public string Birthday { get; set; }
        public List<Account> Accounts { get; set; }
        public Customer() { }
    }
}
