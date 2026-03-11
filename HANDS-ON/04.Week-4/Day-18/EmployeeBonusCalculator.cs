namespace EmployeeBonusCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string empName;
            double salary;
            int experience;
            double bonusPercent;

            Console.WriteLine("Enter Name:");
            empName = Console.ReadLine();

            Console.WriteLine("Enter Salary: ");
            bool validSal = double.TryParse(Console.ReadLine(),  out salary);

            if(validSal == false)
            {
                Console.WriteLine("Invalid salary amount!");
                return;
            }

            Console.WriteLine("Enter Experience: ");
            bool validExp = int.TryParse(Console.ReadLine(), out experience);

            if (validExp == false)
            {
                Console.WriteLine("Invalid experience!");
                return;
            }

            if(salary <= 0)
            {
                Console.WriteLine("Invalid salary!");
                return;
            }

            if(experience < 0 || experience > 40)
            {
                Console.WriteLine("Invalid Experience");
                return;
            }
            else if(experience < 2)
            {
                bonusPercent =   0.05;
            }
            else if (experience <= 5) 
            {
                bonusPercent =   0.1;
            }
            else 
            {
                bonusPercent =   0.15;
            }

            double bonus = salary > 0 ? salary * bonusPercent : 0;
            Console.WriteLine($"Employee: {empName}");
            Console.WriteLine($"Bonus: {bonus}");
            Console.WriteLine("Final Salary: " + (salary + bonus));

        }
    }
}
