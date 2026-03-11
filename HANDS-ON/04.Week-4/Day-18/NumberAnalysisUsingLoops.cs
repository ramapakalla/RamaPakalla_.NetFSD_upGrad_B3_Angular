namespace NumberAnalysisUsingLoops
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            int num;
            Console.WriteLine("Enter Number: ");
            bool validNum = int.TryParse(Console.ReadLine(), out num);
            
            if(validNum == false) {
                Console.WriteLine("Invalid number!");
                return;
            }

            int evenCount = 0, oddCount = 0, sum = 0;
            /*for (int i = 1; i <= num; i++)
            {
                sum += i;
                if (i % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }*/

            int i = 1;
            while (i <= num)
            {
                sum += i;
                if (i % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
                i++;
            }
            Console.WriteLine($"Even Count: {evenCount}");
            Console.WriteLine($"Odd Count: {oddCount}");
            Console.WriteLine($"Sum: {sum}");

        }
    }
}
