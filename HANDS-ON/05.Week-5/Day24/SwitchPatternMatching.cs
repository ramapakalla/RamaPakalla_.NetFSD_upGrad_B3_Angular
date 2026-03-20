using System;

namespace FileHandlingTuplesAndPatternMatching
{
    internal class Program
    {
        static void Main()
        {
            Console.Write("Enter Employee Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Monthly Sales Amount: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal sales))
            {
                Console.WriteLine("Invalid sales input.");
                return;
            }

            Console.Write("Enter Customer Rating (1-5): ");
            if (!int.TryParse(Console.ReadLine(), out int rating) || rating < 1 || rating > 5)
            {
                Console.WriteLine("Invalid rating input.");
                return;
            }

            // Get tuple
            var performanceData = GetPerformanceData(sales, rating);

            // Pattern matching
            string category = performanceData switch
            {
                ( >= 100000, >= 4) => "High Performer",
                ( >= 50000, >= 3) => "Average Performer",
                _ => "Needs Improvement"
            };

           
            Console.WriteLine("\nEmployee Performance ");
            Console.WriteLine($"Employee Name: {name}");
            Console.WriteLine($"Sales Amount: {performanceData.sales}");
            Console.WriteLine($"Rating: {performanceData.rating}");
            Console.WriteLine($"Performance: {category}");
        }

        // Method returning Tuple
        static (decimal sales, int rating) GetPerformanceData(decimal sales, int rating)
        {
            return (sales, rating);
        }
    }
}