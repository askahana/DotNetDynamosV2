namespace DotNetDynamosV2
{
    internal class SavingsAccount : Account
    {
        private decimal interestRate;

        public SavingsAccount(int newAccountNumber, string accountName, string currency, decimal initialBalance, decimal interestRate)
            : base(newAccountNumber, accountName, currency, initialBalance)
        {
            this.interestRate = interestRate;
        }

        public decimal InterestRate
        {
            get { return interestRate; }
            set { interestRate = value; }
        }
    }
}