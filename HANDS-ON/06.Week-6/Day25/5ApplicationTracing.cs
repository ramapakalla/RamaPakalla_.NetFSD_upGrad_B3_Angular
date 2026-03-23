using System.Diagnostics;

namespace AsynchronousProgrammingHandson
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Define log file path
            string logFilePath = "OrderTraceLog.txt";


            // Create TextWriterTraceListener
            TextWriterTraceListener textListener = new TextWriterTraceListener(logFilePath);

            Trace.Listeners.Add(textListener);
            Trace.AutoFlush = true;

            Trace.WriteLine("Application started.");

            try
            {
                ValidateOrder();
                ProcessPayment();
                UpdateInventory();
                GenerateInvoice();


            }
            catch(Exception ex)
            {
                Trace.TraceInformation($"Order processing failed: {ex.Message}");
            }

            Trace.WriteLine("Application finished.");
            Console.WriteLine("Order processing completed. Check log file for trace details.");

            Console.ReadLine();



        }

        static void ValidateOrder()
        {
            Trace.WriteLine("Step 1: Validating order...");
            Console.WriteLine("Validating order...");

        }

        static void ProcessPayment()
        {
            Trace.WriteLine("Step 2: Processing payment...");
            Console.WriteLine("Processing payment...");
        }

        static void UpdateInventory()
        {
            Trace.WriteLine("Step 3: Updating inventory...");
            Console.WriteLine("Updating inventory...");
        }

        static void GenerateInvoice()
        {
            Trace.WriteLine("Step 4: Generating invoice...");
            Console.WriteLine("Generating invoice...");
        }

    }
}
