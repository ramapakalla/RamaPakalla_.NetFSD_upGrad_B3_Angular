using System;

namespace ConsoleApp7
{
    class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message) : base(message)
        {
        }
    }

    class BankAccount
    {
        private decimal _balance;

        public decimal Balance
        {
            get { return  _balance; }
            set { _balance = value; }
        }

        public BankAccount(decimal balance)
        {
            _balance = balance;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Amount should be more than zero");
            }

            if (amount > _balance)
            {
                throw new InsufficientBalanceException("Withdrawal amount exceeds available balance");
            }

            _balance -= amount;
            Console.WriteLine("Withdrawal successful. Remaining balance: " + _balance);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount(3000);

            try
            {
                account.Withdraw(5000);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Transaction attempt completed.");
            }
        }
    }
}