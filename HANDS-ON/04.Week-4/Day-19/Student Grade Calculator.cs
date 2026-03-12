namespace MethodsHandsOn
{
    class Student
    {
        public double CalculateAverage(int m1, int m2,int m3)
        {
            return (m1+m2+m3)/3;
        }

        public void DisplayGrade(double avg)
        {
            char grade;

            if (average >= 80)
                grade = 'A';
            else if (average >= 70)
                grade = 'B';
            else if (average >= 60)
                grade = 'C';
            else if (average >= 50)
                grade = 'D';
            else
                grade = 'F';

            Console.WriteLine("Average = " + avg + ", Grade = " + grade);
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {

            string input = Console.ReadLine();
            string[] marks = input.split(' ');

            int m1 = int.Parse(marks[0]);
            int m2 = int.Parse(marks[1]);
            int m3 = int.Parse(marks[2]);

            Student student = new Student();

            double average = student.CalculateAverage(m1, m2, m3);
            
            student.DisplayGrade(average);

        }
    }
}
