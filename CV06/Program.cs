class CV06
{
    public static void Main(string[] args)
    {
        double totalPlocha = 0;
        double totalPovrch = 0;
        double totalObjem = 0;
        
        GrObjekt[] objekty = new GrObjekt[8];

        objekty[0] = new Kruh(6);
        objekty[1] = new Obdelnik(4, 2);
        objekty[2] = new Elipsa(2, 3);
        objekty[3] = new Trojuhelnik(5, 2);
        objekty[4] = new Kvadr(5);
        objekty[5] = new Valec(5, 10);
        objekty[6] = new Koule(7);
        objekty[7] = new Jehlan(4, 8);

        foreach (GrObjekt i in objekty)
        {
            i.Kresli();
            if (i is Objekt2D)
            {
                Objekt2D y = (Objekt2D)i;
                totalPlocha += y.SpoctiPlochu();
            }
            else if (i is Objekt3D)
            {
                Objekt3D y = (Objekt3D)i;
                totalPovrch += y.SpoctiPovrch();
                totalObjem += y.SpoctiObjem();
            }
        }

        Console.WriteLine();
        Console.WriteLine($"Celkova plocha: {totalPlocha}\nCelkovy povrch: {totalPovrch}\nCelkovy objem: {totalObjem}");
    }
}

public abstract class GrObjekt
{
    public abstract void Kresli();
}

abstract public class Objekt2D : GrObjekt
{
    public abstract double SpoctiPlochu();
}

abstract public class Objekt3D : GrObjekt
{
    public abstract double SpoctiPovrch();

    public abstract double SpoctiObjem();
}

public class Kruh : Objekt2D
{
    private double polomer = 0;
    public Kruh(double polomer)
    {
        this.polomer = polomer;
    }

    public override void Kresli()
    {
        Console.WriteLine($"Kruh (r = {polomer}; S = {SpoctiPlochu()})");
    }

    public override double SpoctiPlochu()
    {
        return (this.polomer * this.polomer * double.Pi);
    }
}

public class Obdelnik : Objekt2D
{
    private double a = 0;
    private double b = 0;
    public Obdelnik(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

    public override void Kresli()
    {
        Console.WriteLine($"Obdlznik (strana a = {this.a}; strana b = {this.b}; S = {SpoctiPlochu()})");
    }

    public override double SpoctiPlochu()
    {
        return a * b;
    }
}

public class Elipsa : Objekt2D
{
    private double a = 0;
    private double b = 0;
    public Elipsa(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

    public override void Kresli()
    {
        Console.WriteLine($"Elipsa (poloosa a = {this.a}; poloosa b = {this.b}; S = {SpoctiPlochu()})");
    }

    public override double SpoctiPlochu()
    {
        return a * b * Double.Pi;
    }
}

public class Trojuhelnik : Objekt2D
{
    private double c = 0;
    private double v = 0;
    public Trojuhelnik(double c, double v)
    {
        this.c = c;
        this.v = v;
    }

    public override void Kresli()
    {
        Console.WriteLine($"Trojuholnik (vyska v = {this.v}; strana kolma na vysku c = {this.c}; S = {SpoctiPlochu()})");
    }

    public override double SpoctiPlochu()
    {
        return 0.5 * v * c;
    }
}

public class Kvadr : Objekt3D
{
    private double a = 0;
    public Kvadr(double a)
    {
        this.a = a;
    }

    public override void Kresli()
    {
        Console.WriteLine($"Kvadr (strana a = {this.a}; S = {SpoctiPovrch()}; V = {SpoctiObjem()})");
    }

    public override double SpoctiPovrch()
    {
        return 6*a*a;
    }

    public override double SpoctiObjem()
    {
        return a * a * a;
    }
}

public class Valec : Objekt3D
{
    private double r = 0;
    private double v = 0;
    public Valec(double r, double v)
    {
        this.r = r;
        this.v = v;
    }

    public override void Kresli()
    {
        Console.WriteLine($"Valec (polomer r = {this.r}; S = {SpoctiPovrch()}; V = {SpoctiObjem()})");
    }

    public override double SpoctiPovrch()
    {
        return (2 * Double.Pi * r * r) + (2 * Double.Pi * r * v);
    }

    public override double SpoctiObjem()
    {
        return (Double.Pi * r * r * v);
    }
}

public class Koule : Objekt3D
{
    private double r = 0;
    public Koule(double r)
    {
        this.r = r;
    }

    public override void Kresli()
    {
        Console.WriteLine($"Gula (polomer r = {this.r}; S = {SpoctiPovrch()}; V = {SpoctiObjem()})");
    }

    public override double SpoctiPovrch()
    {
        return (4.0 * Double.Pi * r * r);
    }

    public override double SpoctiObjem()
    {
        return ((4.0/3.0) * Double.Pi * r * r * r);
    }
}

public class Jehlan : Objekt3D
{
    private double a = 0;
    private double v = 0;
    public Jehlan(double a, double v)
    {
        this.a = a;
        this.v = v;
    }

    public override void Kresli()
    {
        Console.WriteLine($"Jehlan (strana a = {this.a}; vyska v = {this.v}; S = {SpoctiPovrch()}; V = {SpoctiObjem()})");
    }

    public override double SpoctiPovrch()
    {
        return a*(a + Math.Sqrt(4*v*v + a*a));
    }

    public override double SpoctiObjem()
    {
        return (1.0 / 3.0) * a * a * v;
    }
}