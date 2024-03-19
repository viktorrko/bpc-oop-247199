class CV07
{
    public static void Main(string[] args)
    {
        // plnenie objektov
        int[] ints = { 58, 26, 32, 16, 5 };

        string[] strings = { "Test1", "Testik", "Viki", "Nie" };

        Kruh[] kruhs = [new Kruh(3), new Kruh(2), new Kruh(8)];

        Obdelnik[] obdelniks = [new Obdelnik(3, 2), new Obdelnik(2, 1), new Obdelnik(5, 2)];

        Elipsa[] elipsas = [new Elipsa(2, 4), new Elipsa(5, 4), new Elipsa(3, 2)];

        Trojuhelnik[] trojuhelniks = [new Trojuhelnik(1, 2), new Trojuhelnik(5, 2), new Trojuhelnik(2, 2)];

        Ctverec[] ctverecs = [new Ctverec(2), new Ctverec(6), new Ctverec(4)];

        Objekt2D[] objekt2Ds =
        [
            new Kruh(3),
            new Obdelnik(5, 1),
            new Elipsa(2, 3),
            new Trojuhelnik(5, 2),
            new Ctverec(3),
        ];

        // volanie metod na objekty
        Console.WriteLine($"Hodnota max a min integeru: {Extremy.Nejvetsi<int>(ref ints)} | {Extremy.Nejmensi<int>(ref ints)}");
        Console.WriteLine($"Hodnota max a min stringu: {Extremy.Nejvetsi<string>(ref strings)} | {Extremy.Nejmensi<string>(ref strings)}");
        Console.WriteLine($"Hodnota plochy max a min kruhu: {Extremy.Nejvetsi<Kruh>(ref kruhs)} | {Extremy.Nejmensi<Kruh>(ref kruhs)}");
        Console.WriteLine($"Hodnota plochy max a min obdlzniku: {Extremy.Nejvetsi<Obdelnik>(ref obdelniks)} | {Extremy.Nejmensi<Obdelnik>(ref obdelniks)}");
        Console.WriteLine($"Hodnota plochy max a min elipsy: {Extremy.Nejvetsi<Elipsa>(ref elipsas)}; {Extremy.Nejmensi<Elipsa>(ref elipsas)}");
        Console.WriteLine($"Hodnota plochy max a min trojuholniku: {Extremy.Nejvetsi<Trojuhelnik>(ref trojuhelniks)} | {Extremy.Nejmensi<Trojuhelnik>(ref trojuhelniks)}");
        Console.WriteLine($"Hodnota plochy max a min stvorca: {Extremy.Nejvetsi<Ctverec>(ref ctverecs)} | {Extremy.Nejmensi<Ctverec>(ref ctverecs)}");
        Console.WriteLine($"Hodnota plochy max a min 2D objektu: {Extremy.Nejvetsi<Objekt2D>(ref objekt2Ds)} | {Extremy.Nejmensi<Objekt2D>(ref objekt2Ds)}");

        // LINQ
        ints = [1, 3, 5, 7, 9];
        IEnumerable<int> vysledok = from c in ints
                         where c >= 4 && c <= 8
                         select c;

        Console.Write("Vybrane cisla pomocou LINQ: ");
        foreach ( var v in vysledok )
            Console.Write(v + ", ");
    }
}

public interface I2D
{
    double Plocha();
}

public abstract class Objekt2D : I2D, IComparable
{
    public int CompareTo(object obj)
    {
        Objekt2D InObj = (Objekt2D)(obj);

        if (this.Plocha() < InObj.Plocha())
            return -1;
        else if (this.Plocha() > InObj.Plocha())
            return 1;
        else
            return 0;
        // return Plocha().CompareTo(InObj.Plocha());
    }

    public abstract double Plocha();
}

public class Kruh : Objekt2D
{
    private double r = 0;
    
    public Kruh(double r)
    {
        this.r = r;
    }

    public override double Plocha()
    {
        return r * r * Double.Pi;
    }

    public override string ToString()
    {
        return $"r={r}; S={Plocha()}";
    }
}

public class Obdelnik : Objekt2D
{
    private double a, b = 0;

    public Obdelnik(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

    public override double Plocha()
    {
        return a * b;
    }

    public override string ToString()
    {
        return $"a={a}; b={b}; S={Plocha()}";
    }
}

public class Elipsa : Objekt2D
{
    private double a,b = 0;

    public Elipsa(double a, double b)
    {
        this.a = a;
        this.b = b;
    }

    public override double Plocha()
    {
        return a * b * Double.Pi;
    }

    public override string? ToString()
    {
        return $"a={a}; b={b}; S={Plocha()}";
    }
}

public class Trojuhelnik : Objekt2D
{
    private double a, v = 0;

    public Trojuhelnik(double a, double v)
    {
        this.a = a;
        this.v = v;
    }

    public override double Plocha()
    {
        return (1.0/2.0) * a * v;
    }

    public override string? ToString()
    {
        return $"a={a}; v={v}; S={Plocha()}";
    }
}

public class Ctverec : Objekt2D
{
    private double a = 0;

    public Ctverec(double a)
    {
        this.a = a;
    }

    public override double Plocha()
    {
        return a * a;
    }

    public override string? ToString()
    {
        return $"a={a}; S={Plocha()}";
    }
}

class Extremy
{
    public static T Nejvetsi<T>(ref T[] a) where T : IComparable
    {
        T largest = a[0];
        
        foreach (T t in a)
        {
            if (t.CompareTo(largest) > 0)
                largest = t;
        }

        return largest;
    }

    public static T Nejmensi<T>(ref T[] a) where T : IComparable
    {
        T smallest = a[0];

        foreach (T t in a)
        {
            if (t.CompareTo(smallest) < 0)
                smallest = t;
        }

        return smallest;
    }
}