namespace FileHandlingTuplesAndPatternMatching
{

    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter file path: ");
            string filePath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(filePath))
            {
                Console.WriteLine("Invalid file path.");
                return;
            }

            try
            {
                FileInfo fileInfo = new FileInfo(filePath);

                if (!fileInfo.Exists)
                {
                    Console.WriteLine("File doesn't exist.");
                    return;

                }

                Console.WriteLine($"File Name: {fileInfo.Name}");
                Console.WriteLine($"Size: {fileInfo.Length}");
                Console.WriteLine($"Creation Date: {fileInfo.CreationTime.ToString()}");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }


        }
    }
}
