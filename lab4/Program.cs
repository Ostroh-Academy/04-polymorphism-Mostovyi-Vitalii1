using System;

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
        Ellipse shape;

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
                shape = new Ellipse(1, 20);
            }
            else
            {
                shape = new SecondOrderCurve(1, 2, 3, 4, 5, 6);
            }

            shape.PrintCoefficients();

            Console.Write("Введіть координату x: ");
            double x = double.Parse(Console.ReadLine());
            Console.Write("Введіть координату y: ");
            double y = double.Parse(Console.ReadLine());

            if (shape.PointBelongsToCurve(x, y))
                Console.WriteLine($"Точка ({x}, {y}) належить фігурі.");
            else
                Console.WriteLine($"Точка ({x}, {y}) не належить фігурі.");
        } while (true);
    }

}