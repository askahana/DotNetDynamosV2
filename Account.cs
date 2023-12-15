using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetDynamosV2
{
    internal class Account
    {
        public int AccountNumber;
        public string AccountName;
        public string Currency;
        public decimal Balance;

        public Account(int accountnumber, string accountname, string currency, decimal balance)
        {
            AccountNumber = accountnumber;
            AccountName = accountname;
            Currency = currency;
            Balance = balance;
        }
        public Account()
        {
            // Tilldela standardvärden
            AccountNumber = 0;
            AccountName = "Default Account";
            Currency = "SEK";
            Balance = 0.0m;
        }



    }
}
