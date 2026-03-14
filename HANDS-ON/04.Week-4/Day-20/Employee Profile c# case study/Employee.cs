using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp5
{
    class Employee
    {
        private string _fullName;
        private int _age;
        private decimal _salary;

        private readonly string _employeeId;

        public string FullName
        {
            get => _fullName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty.");

                _fullName = value.Trim();
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                if (value <= 18 || value >= 80)
                    throw new ArgumentException("Age must be between 18 and 80.");

                _age = value;
            }
        }

        public decimal Salary
        {
            get => _salary;
            private set
            {
                if (value < 1000)
                    throw new ArgumentException("Salary must be at least 1000.");

                _salary = value;
            }
        }

        public string EmployeeId => _employeeId;

        public Employee(string fullName, decimal salary, int age)
        {
            FullName = fullName;
            Salary = salary;
            Age = age;

            _employeeId = "E" + Guid.NewGuid().ToString("N").Substring(0, 6);
        }

        public void GiveRaise(decimal percentage)
        {
            if (percentage <= 0 || percentage > 30)
                throw new ArgumentException("Raise must be between 0 and 30 percent.");

            Salary += Salary * (percentage / 100);

            Console.WriteLine("Salary increased successfully");
        }

        public bool DeductPenalty(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Penalty must be positive.");

            if (Salary - amount < 1000)
                return false;

            Salary -= amount;
            return true;
        }
    }

}
