using System;

abstract class ShapeFactory
{
    public abstract Ellipse CreateEllipse(double a, double b);
    public abstract SecondOrderCurve CreateSecondOrderCurve(double a11, double a12, double a22, double b1, double b2, double c);
}

class EllipseFactory : ShapeFactory
{
    public override Ellipse CreateEllipse(double a, double b)
    {
        return new Ellipse(a, b);
    }

    public override SecondOrderCurve CreateSecondOrderCurve(double a11, double a12, double a22, double b1, double b2, double c)
    {
        throw new InvalidOperationException("EllipseFactory cannot create SecondOrderCurve.");
    }
}

class SecondOrderCurveFactory : ShapeFactory
{
    public override Ellipse CreateEllipse(double a, double b)
    {
        throw new InvalidOperationException("SecondOrderCurveFactory cannot create Ellipse.");
    }

    public override SecondOrderCurve CreateSecondOrderCurve(double a11, double a12, double a22, double b1, double b2, double c)
    {
        return new SecondOrderCurve(a11, a12, a22, b1, b2, c);
    }
}

class Ellipse
{
    protected double a, b;
    public Ellipse(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

    public virtual void PrintCoefficients()
    {
        Console.WriteLine($"Коефіцієнти еліпса: a = {a}, b = {b}");
    }

    public virtual bool PointBelongsToCurve(double x, double y)
    {
        return (x * x) / (a * a) + (y * y) / (b * b) <= 1;
    }
}

class SecondOrderCurve : Ellipse
{
    private double a11, a12, a22, b1, b2, c;

    public SecondOrderCurve(double a11, double a12, double a22, double b1, double b2, double c)
        : base(0, 0)
    {
        this.a11 = a11;
        this.a12 = a12;
        this.a22 = a22;
        this.b1 = b1;
        this.b2 = b2;
        this.c = c;
    }

    public override void PrintCoefficients()
    {
        Console.WriteLine($"Коефіцієнти кривої другого порядку: a11 = {a11}, a12 = {a12}, a22 = {a22}, b1 = {b1}, b2 = {b2}, c = {c}");
    }

    public override bool PointBelongsToCurve(double x, double y)
    {
        return a11 * x * x + 2 * a12 * x * y + a22 * y * y + b1 * x + b2 * y + c == 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int userChoose;
        ShapeFactory factory;

        do
        {
            Console.WriteLine("Виберіть режим роботи: 1 - робота з еліпсом, 2 - робота з кривою другого порядку, 0 - вихід");
            userChoose = int.Parse(Console.ReadLine());

            if (userChoose == 0)
            {
                Console.WriteLine("Програма завершила свою роботу.");
                break;
            }

            if (userChoose == 1)
            {
                factory = new EllipseFactory();
            }
            else
            {
                factory = new SecondOrderCurveFactory();
            }

            Console.Write("Введіть координату x: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Введіть координату y: ");
            double y = double.Parse(Console.ReadLine());

            if (userChoose == 1)
            {
                Console.Write("Введіть параметр a: ");
                double a = double.Parse(Console.ReadLine());
                Console.Write("Введіть параметр b: ");
                double b = double.Parse(Console.ReadLine());

                Ellipse shape1 = factory.CreateEllipse(a, b);
                shape1.PrintCoefficients();

                if (shape1.PointBelongsToCurve(x, y))
                    Console.WriteLine($"Точка ({x}, {y}) належить фігурі.");
                else
                    Console.WriteLine($"Точка ({x}, {y}) не належить фігурі.");
            }
            else
            {
                Console.Write("Введіть параметр a11: ");
                double a11 = double.Parse(Console.ReadLine());
                Console.Write("Введіть параметр a12: ");
                double a12 = double.Parse(Console.ReadLine());
                Console.Write("Введіть параметр a22: ");
                double a22 = double.Parse(Console.ReadLine());
                Console.Write("Введіть параметр b1: ");
                double b1 = double.Parse(Console.ReadLine());
                Console.Write("Введіть параметр b2: ");
                double b2 = double.Parse(Console.ReadLine());
                Console.Write("Введіть параметр c: ");
                double c = double.Parse(Console.ReadLine());

                SecondOrderCurve shape2 = factory.CreateSecondOrderCurve(a11, a12, a22, b1, b2, c);
                shape2.PrintCoefficients();

                if (shape2.PointBelongsToCurve(x, y))
                    Console.WriteLine($"Точка ({x}, {y}) належить фігурі.");
                else
                    Console.WriteLine($"Точка ({x}, {y}) не належить фігурі.");
            }
        } while (true);
    }
}
