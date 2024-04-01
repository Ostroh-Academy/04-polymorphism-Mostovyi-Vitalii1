using System;

abstract class ShapeFactory
{
    public abstract Ellipse CreateEllipse();
    public abstract SecondOrderCurve CreateSecondOrderCurve();
}

class EllipseFactory : ShapeFactory
{
    public override Ellipse CreateEllipse()
    {
        return new Ellipse(1, 20);
    }

    public override SecondOrderCurve CreateSecondOrderCurve()
    {
        throw new InvalidOperationException("EllipseFactory cannot create SecondOrderCurve.");
    }
}

class SecondOrderCurveFactory : ShapeFactory
{
    public override Ellipse CreateEllipse()
    {
        throw new InvalidOperationException("SecondOrderCurveFactory cannot create Ellipse.");
    }

    public override SecondOrderCurve CreateSecondOrderCurve()
    {
        return new SecondOrderCurve(1, 2, 3, 4, 5, 6);
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

            Ellipse shape1 = factory.CreateEllipse();
            SecondOrderCurve shape2 = factory.CreateSecondOrderCurve();

            shape1.PrintCoefficients();
            shape2.PrintCoefficients();

            Console.Write("Введіть координату x: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Введіть координату y: ");
            double y = double.Parse(Console.ReadLine());

            if (shape1.PointBelongsToCurve(x, y))
                Console.WriteLine($"Точка ({x}, {y}) належить фігурі.");
            else
                Console.WriteLine($"Точка ({x}, {y}) не належить фігурі.");

            if (shape2.PointBelongsToCurve(x, y))
                Console.WriteLine($"Точка ({x}, {y}) належить фігурі.");
            else
                Console.WriteLine($"Точка ({x}, {y}) не належить фігурі.");
        } while (true);
    }

}
