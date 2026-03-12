namespace MethodsHandsOn
{
    class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator1 = new Calculator();
            int a, b;
            Console.WriteLine("Enter first number: ");
            a = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter second number: ");
            b = int.Parse(Console.ReadLine());

            Console.WriteLine("Addition = " + calculator1.Add(a,b) + ", Subtraction = " + calculator1.Subtract(a, b));
        }
    }
}
