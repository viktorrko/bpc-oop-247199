using System.Collections.Generic;
using System.Linq;

class CV08
{
    public static void Main(string[] args)
    {
        ArchivTeplot archivTeplot = new ArchivTeplot();
        archivTeplot.Load("data.txt");

        Console.WriteLine("Vypis teplot");
        archivTeplot.TiskTeplot();
        Console.WriteLine("\nPriemerne teploty za cely rok");
        archivTeplot.TiskPrumernychRocnichTeplot();
        Console.WriteLine("\nPriemerne teploty za kazdy mesiac");
        archivTeplot.TiskPrumernychMesicnichTeplot();

        Console.WriteLine();
        archivTeplot.Kalibrace(-0.1);
        archivTeplot.Save("newdata.txt");
    }
}

class RocniTeplota
{
    int Rok = 0;
    List<double> MesicniTeploty = new List<double>();
    readonly double MaxTeplota;
    readonly double MinTeplota;
    readonly double PrumRocniTeplota;

    public RocniTeplota(int rok, List<double> mesicniTeploty)
    {
        Rok = rok;
        MesicniTeploty = mesicniTeploty;

        MaxTeplota = MesicniTeploty.Max<double>();
        MinTeplota = MesicniTeploty.Min<double>();
        PrumRocniTeplota = MesicniTeploty.Average();
    }

    public List<double> GetMesicniTeploty()
    {  
        return MesicniTeploty;
    }

    public int GetRok()
    {
           return Rok;
    }

    public double GetPrumRocniTeplota()
    {
        return PrumRocniTeplota;
    }

    public string VypisMesicniTeploty(string space)
    {
        return string.Join(space, MesicniTeploty);
    }
    
    public override string? ToString()
    {
        string TempList = "";
        foreach (double i in MesicniTeploty)
        {
            TempList = (TempList + $"{i}; ");
            
        }

        return TempList.Substring(TempList.Length-2);
    }
}

class ArchivTeplot
{
    private SortedDictionary<int, RocniTeplota> _archiv = new SortedDictionary<int, RocniTeplota>();

    public void Save(string filename)
    {
        if (File.Exists(filename))
        {
            File.Delete(filename);
        }

        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (KeyValuePair<int, RocniTeplota> i in _archiv)
            {
                writer.Write($"{i.Key}: ");
                writer.WriteLine(i.Value.VypisMesicniTeploty("; "));
            }
            writer.Close();
            Console.WriteLine("Data boli zapisane do suboru: " + filename);
        }
    }

    public void Load(string filename)
    {
        if (File.Exists(filename))
        {
            _archiv.Clear();
            string line;

            TextReader reader = File.OpenText(filename);
            while ((line = reader.ReadLine()) != null)
            {
                string[] interString = line.Trim().Split(':');

                int tempRok = Int32.Parse(interString[0]);

                string[] interString1 = interString[1].Trim().Split(";");
                List<double> interList = new List<double>();

                foreach (string s in interString1)
                {
                    interList.Add(Double.Parse(s));
                }

                RocniTeplota tempRocniTeplota = new RocniTeplota(tempRok, interList);
                _archiv.Add(tempRok, tempRocniTeplota);
            }
        }
        else
            Console.WriteLine("Subor neexistuje.");
    }

    public void Kalibrace(double increment)
    {
        SortedDictionary<int, RocniTeplota> _tempArchiv = new SortedDictionary<int, RocniTeplota>(_archiv);

        foreach(KeyValuePair<int, RocniTeplota> i in _tempArchiv)
        {
            List<double> list = new List<double>();

            foreach(double d in i.Value.GetMesicniTeploty())
                list.Add(d+increment);

            _archiv[i.Key] = new RocniTeplota(i.Key, list);
        }
    }

    public void Vyhledej(int rok)
    {
        if (_archiv.ContainsKey(rok))
            Console.WriteLine($"{rok}: {_archiv[rok].VypisMesicniTeploty(" ")}");
        else
            Console.WriteLine("Teploty pre tento rok neexistuju");
    }

    public void TiskTeplot()
    {
        foreach (KeyValuePair<int, RocniTeplota> i in _archiv)
            Console.WriteLine($"{i.Value.GetRok()}: {i.Value.VypisMesicniTeploty(" ")}");
    }

    public void TiskPrumernychRocnichTeplot()
    {
        foreach (KeyValuePair<int, RocniTeplota> i in _archiv)
        {
            double temp = i.Value.GetPrumRocniTeplota();

            Console.WriteLine($"{i.Value.GetRok()}: {i.Value.GetPrumRocniTeplota()}");
        }
    }

    public void TiskPrumernychMesicnichTeplot()
    {
        List<Double> avgMesicneTeploty = new List<Double>();
        List<Double> interAvgMesicneTeploty = new List<Double>();

        for (int i = 0; i<12; i++)
        {
            interAvgMesicneTeploty.Clear();
            foreach (KeyValuePair<int, RocniTeplota> y in _archiv)
            {
                interAvgMesicneTeploty.Add(y.Value.GetMesicniTeploty()[i]);
            }
            avgMesicneTeploty.Add(interAvgMesicneTeploty.Average());
        }

        Console.WriteLine("Priemer: " + string.Join("  ", avgMesicneTeploty));
    }
}
