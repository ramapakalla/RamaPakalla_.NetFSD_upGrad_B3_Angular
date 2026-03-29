namespace SolidPrinciplesDemo

{

    //To store student data
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public int Marks { get; set; }
    }

    //To manage student data
    public class StudentRepository
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);

        }

        public List<Student> GetStudents()
        {
            return students;
        }

    }

    //To generate report
    public class ReportGenerator
    {
        public void GenerateReport(List<Student> students)
        {
            Console.WriteLine("Student Performance Report");
            Console.WriteLine("---------------------------");

            foreach (var student in students)
            {
                Console.WriteLine($"Student Id: {student.StudentId}");
                Console.WriteLine($"Name: {student.StudentName}");
                Console.WriteLine($"Marks: {student.Marks}");
                Console.WriteLine("------------------------------");


            }

        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
           StudentRepository studentRepository = new StudentRepository();

            studentRepository.AddStudent(new Student {StudentId = 1, StudentName = "Rama", Marks = 85 });
            studentRepository.AddStudent(new Student { StudentId = 2, StudentName = "Pranathi", Marks = 92 });

            ReportGenerator reportGenerator = new ReportGenerator();
            reportGenerator.GenerateReport(studentRepository.GetStudents());

            Console.ReadLine();
        }
    }
}
