using System.Text;

namespace FileHandlingTuplesAndPatternMatching
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "log.txt";

            try
            {
                Console.Write("Enter your message: ");
                string message = Console.ReadLine();

                
                byte[] data = Encoding.UTF8.GetBytes(message + Environment.NewLine);

                
                using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                {
                    fs.Write(data, 0, data.Length);
                }

                Console.WriteLine("Message written to file successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
        }
    }
}
