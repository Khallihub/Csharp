
namespace MyShapes
{

    public class Shape
    {
        public string? Name { get; protected set; }

        public virtual double CalculateArea()
        {
            return 0;
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            Name = "Circle";
            Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Rectangle : Shape
    {
        public double Width { get; }
        public double Height { get; }

        public Rectangle(double width, double height)
        {
            Name = "Rectangle";
            Width = width;
            Height = height;
        }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    public class Triangle : Shape
    {
        public double Base { get; }
        public double TriangleHeight { get; }

        public Triangle(double triangleBase, double height)
        {
            Name = "Triangle";
            Base = triangleBase;
            TriangleHeight = height;
        }

        public override double CalculateArea()
        {
            return (Base * TriangleHeight) / 2;
        }
    }

    public class Program
    {
        public static void PrintShapeArea(Shape shape)
        {
            double area = shape.CalculateArea();
            Console.WriteLine($"Shape: {shape.Name}, Area: {area}");
        }

        public static void Main(string[] args)
        {
            Circle circle = new Circle(5);
            Rectangle rectangle = new Rectangle(4, 6);
            Triangle triangle = new Triangle(3, 4);

            PrintShapeArea(circle);
            PrintShapeArea(rectangle);
            PrintShapeArea(triangle);
        }
    }


}
