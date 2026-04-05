using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public string Course { get; set; }
}

interface IStudentRepository
{
    void AddStudent(Student student);
    List<Student> GetAllStudents();
    Student GetStudentById(int id);
    void DeleteStudent(int id);
}

class StudentRepository : IStudentRepository
{
    private List<Student> students = new List<Student>();

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public List<Student> GetAllStudents()
    {
        return students;
    }

    public Student GetStudentById(int id)
    {
        return students.FirstOrDefault(s => s.StudentId == id);
    }

    public void DeleteStudent(int id)
    {
        var student = students.FirstOrDefault(s => s.StudentId == id);
        if (student != null)
        {
            students.Remove(student);
        }
    }
}

class Program
{
    static void Main()
    {
        IStudentRepository repo = new StudentRepository();

        repo.AddStudent(new Student { StudentId = 1, StudentName = "Ravi", Course = "C#" });
        repo.AddStudent(new Student { StudentId = 2, StudentName = "Anita", Course = "ASP.NET" });

        Console.WriteLine("All Students:");

        foreach (var s in repo.GetAllStudents())
        {
            Console.WriteLine(s.StudentId + " " + s.StudentName + " " + s.Course);
        }

        Console.WriteLine("\nFind Student by ID:");

        var student = repo.GetStudentById(1);
        Console.WriteLine(student.StudentName);

        repo.DeleteStudent(2);

        Console.WriteLine("\nAfter Deleting Student 2:");

        foreach (var s in repo.GetAllStudents())
        {
            Console.WriteLine(s.StudentId + " " + s.StudentName);
        }
    }
}