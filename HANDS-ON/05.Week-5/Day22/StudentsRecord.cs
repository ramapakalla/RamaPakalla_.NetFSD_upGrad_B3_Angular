namespace ConsoleApp7
{

    public record Student(int RollNo,string Name, string Course,int Marks);
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();

            Console.WriteLine("Enter number of students: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                Console.Write("\nEnter Roll Number: ");
                int roll = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Course: ");
                string course = Console.ReadLine();

                Console.Write("Enter Marks: ");
                int marks = int.Parse(Console.ReadLine());

                students.Add(new Student(roll,name,course,marks));

            }

            Console.WriteLine("\nStudent Records:");

            students.ForEach(s => 
            Console.WriteLine("Roll No: " + s.RollNo +
                              " | Name: " + s.Name +
                              " | Course: " + s.Course +
                              " | Marks: " + s.Marks));

            Console.WriteLine("\nSearch Roll Number: ");
            int searchRoll = int.Parse(Console.ReadLine());

            Student result = students.Find(s => s.RollNo == searchRoll);

            Console.WriteLine("\nSearch Result: ");
            if (result == null)
            {
                Console.WriteLine("Student record not found.");
            }
            else
            {
                Console.WriteLine("Roll No: " + result.RollNo +
                              " | Name: " + result.Name +
                              " | Course: " + result.Course +
                              " | Marks: " + result.Marks);
            }


        }
    }
}
