using System;
using System.Text.Unicode;

class Celipsoid
{
    public int a1, a2, a3, b1, b2, b3;
    public double v;

    virtual public void inita()
    {
        Console.WriteLine("Введіть напіввісі еліпсоїда a1, a2, a3:");
        a1 = Convert.ToInt32(Console.ReadLine());
        a2 = Convert.ToInt32(Console.ReadLine());
        a3 = Convert.ToInt32(Console.ReadLine());
    }

    virtual public void initb()
    {
        Console.WriteLine("Введіть координати зміщення центру b1, b2, b3:");
        b1 = Convert.ToInt32(Console.ReadLine());
        b2 = Convert.ToInt32(Console.ReadLine());
        b3 = Convert.ToInt32(Console.ReadLine());
    }

    virtual public void show()
    {
        Console.WriteLine("a1= " + a1);
        Console.WriteLine("a2= " + a2);
        Console.WriteLine("a3= " + a3);
        Console.WriteLine("b1= " + b1);
        Console.WriteLine("b2= " + b2);
        Console.WriteLine("b3= " + b3);
    }

    virtual public double size()
    {
        v = 4.0 * a1 * a2 * a3 / 3.0;
        Console.Write("Об'єм еліпсоїда = ");
        Console.WriteLine(v);
        return v;
    }
}

class Cball : Celipsoid
{
    public int r;

    public override void inita()
    {
        Console.Write("Введіть радіус кулі:");
        r = Convert.ToInt32(Console.ReadLine());
        base.initb();
    }

    public override void show()
    {
        Console.WriteLine("r= " + r);
        Console.WriteLine("b1= " + b1);
        Console.WriteLine("b2= " + b2);
        Console.WriteLine("b3= " + b3);
    }

    public override double size()
    {
        v = 4.0 * r * r * r / 3.0;
        Console.Write("Об'єм кулі = ");
        Console.WriteLine(v);
        return v;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int userSelect;
        Celipsoid baseobj = new Celipsoid();
        do
        {
            Console.WriteLine("Введіть '0', якщо ви хочете працювати з еліпсоїдом, та '1' - з кулею");
            userSelect = Convert.ToInt32(Console.ReadLine());
            if (userSelect == 0)
            {
                baseobj = new Celipsoid();
                baseobj.initb();
            }
            else if (userSelect == 1)
            {
                baseobj = new Cball();
            }
            else
            {
                return;
            }
            baseobj.inita();
            baseobj.show();
            baseobj.size();
        } while (true);
    }
}
