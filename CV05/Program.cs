class CV05
{
    public static void Main(string[] args)
    {
        Osobni Ford = new Osobni("Benzin", 50, 3);
        Ford.Natankuj("benzin", 20);

        // neplatne zadane palivo
        try
        {
            Osobni Skoda = new Osobni("elektrika", 20, 5);
        }
        catch (Exception e) 
        {
            Console.WriteLine("! Chyba !\n" + e.Message + "\n");
        }

        // neplatne tankovanie
        try
        {
            Ford.Natankuj("nafta", 20);

        }
        catch (Exception e)
        {
            Console.WriteLine("! Chyba !\n" + e.Message + "\n");
        }

        // neplatne tankovanie
        try
        {
            Ford.Natankuj("benzin", 50);
        }
        catch (Exception e)
        {
            Console.WriteLine("! Chyba !\n" + e.Message + "\n");
        }
        
        
        // status c.1
        Console.WriteLine(Ford.ToString());
        Console.WriteLine();
        Console.WriteLine(Ford.myAutoradio.ToString());
        Console.WriteLine();

        // nastavenie autoradia
        Ford.myAutoradio.NastavPredvolbu(0, 90);
        Ford.myAutoradio.PreladNaPredvolbu(0);

        // status c.2
        Console.WriteLine(Ford.myAutoradio.ToString());
        Console.WriteLine();

        // neplatna predvolba radia
        try
        {
            Ford.myAutoradio.PreladNaPredvolbu(2);
        }
        catch (Exception e)
        {
            Console.WriteLine("! Chyba !\n" + e.Message + "\n");
        }
    }

}

class Auto
{
    protected enum TypPaliva
    {
        benzin,
        nafta,
    }
    protected int VelikostNadrze = 0;
    protected int StavNadrze = 0;
    protected string Palivo = "";

    public Autoradio myAutoradio = new();

    public void Natankuj(string typPaliva, int mnozstvi)
    {
        if (typPaliva.ToLower() == Palivo.ToLower())

            if (StavNadrze + mnozstvi < VelikostNadrze)
                StavNadrze += mnozstvi;
            else
                throw new Exception("Zadali ste prilis velke mnozstvo paliva.");

        else
            throw new Exception("Tento typ paliva nemozte do vozidla natankovat.");
    }
}

class Osobni : Auto
{
    private int MaxOsob;
    private int PrepravovaneOsoby;

    public Osobni(string TypPalivaIn, int VelikostNadrzeIn, int MaxOsobIn)
    {
        // TypPaliva check
        if (Enum.IsDefined(typeof(TypPaliva), TypPalivaIn.ToLower()))
            Palivo = TypPalivaIn;
        else
            throw new Exception("Neplatny typ paliva.");

        // MaxOsob check
        if (MaxOsobIn > 10 || MaxOsobIn < 0)
            throw new Exception("Neplatna hodnota maximalneho poctu osob.");
        else
            MaxOsob = MaxOsobIn;

        VelikostNadrze = VelikostNadrzeIn;
        PrepravovaneOsoby = 0;
    }

    public override string ToString()
    {
        return $"Stav nadrze: {StavNadrze}\nPrepravovane osoby: {PrepravovaneOsoby}";
    }
}

class Nakladni : Auto
{
    private int MaxNaklad = 0;
    private int PrepravovanyNaklad = 0;

    public Nakladni(string TypPalivaIn, int VelikostNadrzeIn, int MaxNakladIn)
    {
        // TypPaliva check
        if (Enum.IsDefined(typeof(TypPaliva), TypPalivaIn.ToLower()))
            Palivo = TypPalivaIn;
        else
            throw new Exception("Neplatny typ paliva.");

        // MaxNaklad check
        if (MaxNakladIn > 500 || MaxNakladIn < 0)
            throw new Exception("Neplatna hodnota maximalneho nakladu.");
        else
            MaxNaklad = MaxNakladIn;

        VelikostNadrze = VelikostNadrzeIn;
        PrepravovanyNaklad = 0;
    }

    public override string ToString()
    {
        return $"Stav nadrze: {StavNadrze}\nPrepravovany naklad: {PrepravovanyNaklad}";
    }
}

class Autoradio
{
    private int NaladenyKmitocet = 0;
    private bool RadioZapnuto = false;
    private Dictionary<int, int> presets = new Dictionary<int, int>();

    public void NastavPredvolbu(int cislo, int kmitocet)
    {
        if (!presets.ContainsKey(cislo))
            presets.Add(cislo, kmitocet);
        else
            presets[cislo] = kmitocet;
    }

    public void PreladNaPredvolbu(int cislo)
    {
        if (presets.ContainsKey(cislo))
        {
            NaladenyKmitocet = presets[cislo];
            RadioZapnuto = true;
        }
        else
            throw new Exception("Predvolba nieje definovana.");
    }

    public override string ToString()
    {
        return $"Radio zapnute: {RadioZapnuto}\nFrekvencia radia: {NaladenyKmitocet}";
    }
}