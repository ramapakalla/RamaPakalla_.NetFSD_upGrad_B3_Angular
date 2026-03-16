namespace ConsoleApp6
{
    class Product
    {
        private string _productName;
        private decimal _price;


        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Price cannot be negative.");
                }
                else
                {
                    _price = value;
                }
            }
        }

        public virtual decimal CalculateDiscount() {
            return Price;
        }

    }



    class Electronics : Product
    {
        public override decimal CalculateDiscount()
        {
            return Price - (Price * 0.05m);
        }
    }

    class Clothing : Product
    {
        public override decimal CalculateDiscount()
        {
            return Price - (Price * 0.15m);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Product electronics = new Electronics();

            electronics.Price = 20000;

            Console.WriteLine("Final Price after 5% discount = " + electronics.CalculateDiscount());



            Product clothing = new Clothing();

            clothing.Price = 25000;

            Console.WriteLine("Final Price after 15% discount = " + clothing.CalculateDiscount());




        }
    }
}