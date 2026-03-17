namespace ConsoleApp7
{
    class Calculator
    {
        public double Divide(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new DivideByZeroException();

            return (double)numerator / denominator;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new Calculator();

            try
            {
                Console.WriteLine("Quotient: " + calculator.Divide(20, 0));
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Error: Cannot divide by zero");
            }
            finally
            {
                Console.WriteLine("Operation completed safely");
            }
        }
    }
}