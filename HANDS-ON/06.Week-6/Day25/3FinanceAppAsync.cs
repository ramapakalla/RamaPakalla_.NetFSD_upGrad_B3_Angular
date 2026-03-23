namespace AsynchronousProgrammingHandson
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting report generation...\n");

            Task salesTask = Task.Run(()=> GenerateSalesReport());
            Task inventoryTask = Task.Run(()=> GenerateInventoryReport());
            Task customerTask = Task.Run(()=> GenerateCustomerReport());

            await Task.WhenAll(salesTask, inventoryTask, customerTask);

            Console.WriteLine("\nAll reports have been generated.");
            Console.ReadLine();
        }

        static async Task GenerateSalesReport()
        {
            Console.WriteLine("Sales Report generation started...");
            await Task.Delay(3000); 
            Console.WriteLine("Sales Report generation completed.");

        }

        static async Task GenerateInventoryReport()
        {
            Console.WriteLine("Inventory Report generation started...");
            await Task.Delay(3000); 
            Console.WriteLine("Inventory Report generation completed.");

        }

        static async Task GenerateCustomerReport()
        {
            Console.WriteLine("Customer Report generation started...");
            await Task.Delay(3000); 
            Console.WriteLine("Customer Report generation completed.");

        }
    }
}
