namespace ConsoleApp6
{
    class Vehicle
    {
        private string _brand;
        private decimal _rentalRatePerDay;


        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        public decimal RentalRatePerDay
        {
            get { return _rentalRatePerDay; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Rate cannot be negative");

                _rentalRatePerDay = value;
            }
        }

        public virtual decimal CalculateRental(int days) {
            if(days <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(days));
            }
            return RentalRatePerDay * days;
        }

    }



    class Car : Vehicle
    {
        public override decimal CalculateRental(int days)
        {
            decimal baseCost = base.CalculateRental(days);
            return baseCost + 500;

        }
    }
        class Bike : Vehicle
    {
        public override decimal CalculateRental(int days)
        {
            decimal total = base.CalculateRental(days);
            return total - (total * 0.05m);

        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
           Vehicle car = new Car();
            car.RentalRatePerDay = 2000;
            Console.WriteLine("Total Rental = " + car.CalculateRental(3));

            Vehicle bike = new Bike();
            bike.RentalRatePerDay = 850;
            Console.WriteLine("Total Rental = " + bike.CalculateRental(2));



        }
    }
}