using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class Customer : User, ICustomer
    {
        public string Email { get; set; }
        public string Birthday { get; set; }
        public List<Account> Accounts { get; set; }
        public object Loans { get; internal set; }

        public Customer() { }
    }
}
