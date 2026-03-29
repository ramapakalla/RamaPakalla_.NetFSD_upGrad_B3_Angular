namespace SolidPrinciplesDemo
{

    //Interface
    public interface IDiscountStrategy
    {
        double CalculateDiscount(double amount);
    }

    //Regular customer discount
    public class RegularCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.05; // 5% discount 
        }
     
    }


    //Premium customer discount
    public class PremiumCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.10; // 10% discount 
        }

    }


    //VIP customer discount
    public class VipCustomerDiscount : IDiscountStrategy
    {
        public double CalculateDiscount(double amount)
        {
            return amount * 0.20; // 20% discount 
        }

    }


    // Discount calculator
    public class DiscountCalculator
    {
        public double GetFinalPrice(double amount, IDiscountStrategy discountStrategy)
        {
            double discount = discountStrategy.CalculateDiscount(amount);
            return amount - discount;
        }
    }



    internal class Program
    {
        static void Main(string[] args)
        {
          DiscountCalculator discountCalculator = new DiscountCalculator();

            Console.WriteLine("Enter amount: ");
            double amount = double.Parse(Console.ReadLine());

            IDiscountStrategy regular = new RegularCustomerDiscount();
            IDiscountStrategy premium = new PremiumCustomerDiscount();
            IDiscountStrategy vip = new VipCustomerDiscount();

            Console.WriteLine("Regular Customer Final Price: " + discountCalculator.GetFinalPrice(amount, regular));
            Console.WriteLine("Premium Customer Final Price: " + discountCalculator.GetFinalPrice(amount, premium));
            Console.WriteLine("VIP Customer Final Price: " + discountCalculator.GetFinalPrice(amount, vip));




            Console.ReadLine();
        }
    }
}
