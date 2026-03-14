using System;

namespace ConsoleApp5
{
   
    internal class Program
    {
        static void Main()
        {
            var emp = new Employee("Rama Pakalla", 12000m, 23);

            emp.GiveRaise(20);

            Console.WriteLine("After raise: " + emp.Salary);

            bool success = emp.DeductPenalty(1000);

            //  emp.DeductPenalty(-500); // not allowed


            Console.WriteLine("After penality: " + emp.Salary);

        }
    }
}