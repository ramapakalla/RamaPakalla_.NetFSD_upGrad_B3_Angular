namespace AsynchronousProgrammingHandson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Product Name: ");
            string productName = Console.ReadLine();

            Console.WriteLine("Enter Product Price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Discount Percentage: ");
            double discount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("\n-----Product details-----");
            Console.WriteLine($"Product name: {productName}");
            Console.WriteLine($"Original Price: {price}");
            Console.WriteLine($"Discount: {discount}");
            Console.WriteLine($"Final Amount: {CalculateFinalPrice(price,discount)}");


            Console.ReadLine();

        }

        static double CalculateFinalPrice(double price,double discount)
        {
            double discountAmount = price * discount / 100;
            double finalPrice = price - discountAmount;
            return finalPrice;
        }
    }
}
