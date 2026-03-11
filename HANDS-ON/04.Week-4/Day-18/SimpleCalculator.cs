namespace SimpleCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1, num2;
            Console.WriteLine("Enter number - 1 :  ");
            bool validNum1 = int.TryParse(Console.ReadLine(), out num1);

            if (validNum1 == false)
            {
                Console.WriteLine("Invalid number.");
                return;
            }

            Console.WriteLine("Enter number - 2 : ");
            bool validNum2 = int.TryParse(Console.ReadLine(), out num2);

            if (validNum2 == false)
            {
                Console.WriteLine("Invalid number.");
                return;
            }

            Console.WriteLine("Enter Operator [ +  -  *  / ]:  ");
            char op = char.Parse(Console.ReadLine());

            int result = 0;

            // Switch Case
            
            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    break;

                case '-':
                    result = num1 - num2;
                    break;

                case '*':
                    result = num1 * num2;
                    break;

                case '/':
                    if(num2 == 0)
                    {
                        Console.WriteLine("Cannot divide by zero");
                        return;
                    }
                    result = num1 / num2;
                    break;

                default:
                    Console.WriteLine("Invalid Operation");
                    Console.ReadLine();
                    return;
            }


            Console.WriteLine("Final Result : " + result);

            Console.ReadLine();
        }
    }
}
