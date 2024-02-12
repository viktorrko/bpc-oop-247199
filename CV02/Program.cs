Complex x = new(2.0, 1.0);
Complex y = new(1.0, 2.0);
Complex refer = new(3.0, 4.0);

TestComplex.Test(Complex.Add(x, y), refer, "Sucet");
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
            Console.Write($"\nChyba! Ocakavana hodnota: {Complex.Display(refer)} Skutocna hodnota: {Complex.Display(calc)}");
        }
    }
}