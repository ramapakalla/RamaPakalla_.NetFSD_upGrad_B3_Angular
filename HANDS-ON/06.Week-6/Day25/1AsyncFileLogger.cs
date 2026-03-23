using System;
using System.IO;
using System.Threading.Tasks;

namespace AsynchronousProgrammingHandson
{
    internal class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Application Started");

            Task log1 = await WriteLogAsync("User logged in");
            Task log2 = await WriteLogAsync("File uploaded");
            Task log3 = await WriteLogAsync("Payment processed");

            Console.WriteLine("Main thread is still running...");

            await Task.WhenAll(log1, log2, log3);

            Console.WriteLine("All logs written.");
        }

        public static async Task WriteLogAsync(string message)
        {
            await Task.Delay(1000); 

            using (StreamWriter writer = new StreamWriter("TestFile.txt", true))
            {
                await writer.WriteLineAsync($"{DateTime.Now}: {message}");
            }

            Console.WriteLine($"Log written: {message}");
        }
    }
}