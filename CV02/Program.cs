class CV02
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Testujem cisla x=(1 + i2) a y=(2 + i3)");
        Complex x = new(1.0, 2.0);
        Complex y = new(2.0, 3.0);

        TestComplex.Test(Complex.Add(x, y), new(3.0, 5.0), "Sucet");
        TestComplex.Test(Complex.Substract(x, y), new(-1.0, -1.0), "Odcitanie");
        TestComplex.Test(Complex.Multiply(x, y), new(-4.0, +7.0), "Nasobenie");
        TestComplex.Test(Complex.Divide(x, y), new(0.6154, 0.07692), "Delenie");    //  new(0.6153846154, 0.07692307692)
        TestComplex.Test(Complex.Decrement(x), new(0, 1.0), "Dekrement");
        TestComplex.Test(Complex.Conjugate(x), new(1.0, -2.0), "Komplexne zdruzene");
        Console.WriteLine("Cisla sa rovnaju: " + Complex.Equals(x, y));
        Console.WriteLine("Cisla sa nerovnaju: " + Complex.equalsNot(x, y));
        Console.WriteLine("Modul: " + Complex.Modul(x));
        Console.WriteLine("Argument: " + Complex.Arg(x));

    }
}

class Complex
{
    static readonly char imUnit = 'i';
    public double Realna;
    public double Imaginarni;

    public Complex(double re, double im)
    {
        Realna = re;
        Imaginarni = im;
    }

    // vrati string s komplexnym cislom v algebraickom tvare
    public override string ToString()
    {
        char sign = '+';
        if (Imaginarni < 0)
        {
            sign = '-';     // ak je imaginarna zlozka zaporna tak sa zmeni znamienko
        }

        return ($"{Realna} {sign} {imUnit}{Math.Abs(Imaginarni)}");
    }

    /*
    DEPRECATED !!
    public static string Display(Complex x)
    {
        char sign = '+';
        if (x.Imaginarni < 0)
        {
            sign = '-';     // ak je imaginarna zlozka zaporna tak sa zmeni znamienko
        }

        // rovnaka funkcia ale so string interpolation (efektivnejsie?)
        // return $"{x.Realna}{sign}{imUnit}{x.Imaginarni}");

        return x.Realna.ToString() + sign + imUnit + Math.Abs(x.Imaginarni).ToString();
    }
    */

    // +
    public static Complex Add(Complex x, Complex y)
    {
        
        double newRe = x.Realna + y.Realna;
        double newIm = x.Imaginarni + y.Imaginarni;

        return new Complex(newRe, newIm);
    }

    // -
    public static Complex Substract(Complex x, Complex y)
    {

        double newRe = x.Realna - y.Realna;
        double newIm = x.Imaginarni - y.Imaginarni;

        return new Complex(newRe, newIm);
    }

    // *
    public static Complex Multiply(Complex x, Complex y)
    {

        double newRe = (x.Realna * y.Realna) - (x.Imaginarni * y.Imaginarni);
        double newIm = (x.Realna * y.Imaginarni) + (x.Imaginarni * y.Realna);

        return new Complex(newRe, newIm);
    }

    // /
    public static Complex Divide(Complex x, Complex y)
    {
        double divisor = y.Realna * y.Realna + y.Imaginarni * y.Imaginarni;     // medzikrok
        double newRe = (x.Realna * y.Realna + x.Imaginarni * y.Imaginarni) / divisor;
        double newIm = (x.Imaginarni * y.Realna - x.Realna * y.Imaginarni) / divisor; 

        return new Complex(newRe, newIm);
    }
       
    // ==
    public static bool Equals(Complex x, Complex y)
    {
        if (x.Realna == y.Realna && x.Imaginarni == y.Imaginarni) return true;
        else return false;
    }

    // !=
    public static bool equalsNot(Complex x, Complex y)
    {
        if (Equals(x, y)) return false;
        else return true;
    }

    // unarny dekrement
    public static Complex Decrement(Complex x)
    {
        double newRe = x.Realna - 1;
        double newIm = x.Imaginarni - 1;

        return new Complex(newRe, newIm);
    }

    // komplexne zdruzene
    public static Complex Conjugate(Complex x)
    {
        double newIm = x.Imaginarni * -1;

        return new Complex(x.Realna, newIm);
    }

    // modul
    public static double Modul(Complex x)
    {
        return Math.Sqrt((x.Realna * x.Realna) + (x.Imaginarni * x.Imaginarni));
    }

    // argument
    public static double Arg(Complex x)
    {
        return Math.Atan2(x.Imaginarni, x.Realna);
    }
};

class TestComplex
{
    static readonly double epsilon = 1E-6;

    public static void Test(Complex calc, Complex refer, string Name)
    {
        Console.Write($"Test {Name}: ");

        if (Math.Abs(calc.Realna - refer.Realna) < epsilon && Math.Abs(calc.Imaginarni - refer.Imaginarni) < epsilon)
        {
            Console.WriteLine("OK!");
        }
        else
        {
            Console.Write($"ERROR! \nOcakavana hodnota: {refer} Skutocna hodnota: {calc}\n");
        }
    }
}