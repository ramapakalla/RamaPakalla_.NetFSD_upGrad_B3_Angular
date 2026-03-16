namespace ConsoleApp6
{
    class BankAccount
    {
        private long _accountNumber;
        public decimal Balance { get; private set; }
        public long AccountNumber
        {
            get { return _accountNumber; }
        }

        public BankAccount(long accountNumber)
        {
            _accountNumber = accountNumber;
            Balance = 0;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            Balance += amount;
            Console.WriteLine($"Deposit successful. Balance: {Balance}");
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be greater than zero.");

            if (amount > Balance)
                throw new InvalidOperationException("Insufficient balance.");

            Balance -= amount;
            Console.WriteLine($"Withdraw successful. Balance: {Balance}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount(198377367);

            account.Deposit(5000);

            account.Withdraw(2000);

            Console.WriteLine("Current Balance: " + account.Balance);
        }
    }
}