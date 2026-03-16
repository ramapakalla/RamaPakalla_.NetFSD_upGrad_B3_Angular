namespace ConsoleApp6
{
    class Employee
    {
        private string _employeeName;
        private decimal _baseSalary;

        public string EmployeeName
        {
            get; set;
        }

        public decimal BaseSalary
        {
            get; set;
        }

        public virtual decimal CalculateSalary() {
            return BaseSalary;
        }

    }

    class Manager : Employee
    {
        public override decimal CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.20m);
        }
    }

    class Developer : Employee
    {
        public override decimal CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.10m);
        }

    }

        internal class Program
    {
        static void Main(string[] args)
        {
            decimal baseSalary = 50000;

            Employee manager = new Manager();
            manager.BaseSalary = baseSalary;
            manager.EmployeeName = "Ravi";
           
            Employee developer = new Developer();
            developer.BaseSalary = baseSalary;
            developer.EmployeeName = "Arjun";


            Console.WriteLine("Manager Salary = " + manager.CalculateSalary() + ", Developer Salary = " + developer.CalculateSalary());
        }
    }
}