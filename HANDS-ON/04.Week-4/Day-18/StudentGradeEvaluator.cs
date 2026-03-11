namespace StudentGradeEvaluator

{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            int marks;
            String grade;

        
            Console.WriteLine("Enter Name: ");
            name = Console.ReadLine();

            Console.WriteLine("Enter Marks: ");
            bool validInput = int.TryParse(Console.ReadLine(), out marks);
            if (validInput == false)
            {
                Console.WriteLine("Invalid Number format.");
                Console.ReadLine();
                return; // exit or return from Main
            }


            if (marks < 0 || marks > 100)
            {
                Console.WriteLine("Invalid Marks! Marks should be between 0 and 100");
                return;
            }
            else if (marks >= 80)
                grade = "A";

            else if (marks >= 70)

                grade = "B";

            else if (marks >= 60)

                grade = "C";

            else if (marks >= 50)

                grade = "D";

            else
                grade = "Fail";
            
            Console.WriteLine($"Student: {name}");
            Console.WriteLine($"Grade: {grade}");

        }
    }
}
