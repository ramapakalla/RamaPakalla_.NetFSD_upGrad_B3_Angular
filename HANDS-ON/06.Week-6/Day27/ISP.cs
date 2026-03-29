namespace SolidPrinciplesDemo
{

    // Interfaces
    public interface IPrinter
    {
        void Print();
    }

    public interface IScanner
    {
        void Scan();
    }

    public interface IFax
    {
        void Fax();
    }




    // Basic printer (Print only)
    public class BasicPrinter : IPrinter
    {
        public void Print()
        {
            Console.WriteLine("Basic Printer: Printing document...");
        }
    }


    // Advanced printer (Print + Scan + Fax)
    public class AdvancedPrinter : IPrinter, IScanner, IFax
    {
        public void Print()
        {
            Console.WriteLine("Advanced Printer: Printing document...");
        }

        public void Scan()
        {
            Console.WriteLine("Advanced Printer: Scanning document...");
        }

        public void Fax()
        {
            Console.WriteLine("Advanced Printer: Sending fax...");
        }

    }




    internal class Program
    {
        static void Main(string[] args)
        {
           BasicPrinter basic = new BasicPrinter();
            basic.Print();

            AdvancedPrinter advanced = new AdvancedPrinter();
            advanced.Print();
            advanced.Scan();
            advanced.Fax();

            Console.ReadLine();
        }

       
    }
}
