using System.Collections.ObjectModel;

namespace MethodsHandsOn
{
    class Product
    {
        private readonly int _productId;
        private string _productName;
        private double _unitPrice;
        private int _quantity;


        public Product(int productId)
        {
            _productId = productId;
        }


        public int ProductId
        {
            get { return _productId; }
        }

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        public double UnitPrice
        {
            get { return _unitPrice; }
            set { _unitPrice = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public void ShowDetails()
        {
            Console.WriteLine("\nProduct Details");
            Console.WriteLine("Product Id: " + ProductId);
            Console.WriteLine("Product Name: " + ProductName);
            Console.WriteLine("Unit Price: " + UnitPrice);
            Console.WriteLine("Quantity: " + Quantity);
            Console.WriteLine("Total Amount: " + (UnitPrice * Quantity));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Product Id: ");
            int id = int.Parse(Console.ReadLine());

            Product product = new Product(id);

            Console.Write("Enter Product Name: ");
            product.ProductName = Console.ReadLine();

            Console.Write("Enter Unit Price: ");
            product.UnitPrice = double.Parse(Console.ReadLine());

            Console.Write("Enter Quantity: ");
            product.Quantity = int.Parse(Console.ReadLine());

            product.ShowDetails();
        }
    }
}