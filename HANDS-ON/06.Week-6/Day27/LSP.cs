namespace SolidPrinciplesDemo
{

    // Base class
    public abstract class Shape
    {
        public abstract double CalculateArea();
    }

    //Regular customer discount
    public class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public Rectangle(double length, double width)
        {
            this.Length = length;
            this.Width = width;
        }
        public override double CalculateArea()
        {
             return Length * Width;
        }
     
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            this.Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI *  Radius * Radius;
        }

    }




    internal class Program
    {
        static void Main(string[] args)
        {
            Shape Rectangle = new Rectangle(5, 4);
            Shape Circle = new Circle(5);

            Console.WriteLine("Rectangle: ");
            PrintArea(Rectangle);

            Console.WriteLine("Circle: ");
            PrintArea(Circle);

            Console.ReadLine();

        }

        static void PrintArea(Shape shape)
        {
            Console.WriteLine("Area: " + shape.CalculateArea().ToString("F2"));
        }
    }
}
