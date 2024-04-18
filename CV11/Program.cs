using CV11.EFCore;

static void Main(string[] args)
{
    using (var dbContext = new VyukaContext())
    {
        var repository = new Repository(dbContext);

        repository.AddPredmetData("BOOP", "Programovanie");
        repository.PrintPredmety();
    }
    
}


public class Repository
{
    private readonly VyukaContext _dbContext;

    public Repository(VyukaContext dbContext)
    {
        _dbContext = dbContext;
    }

    // pridanie dat studenta
    public void AddStudentData(int inStudentId, string inJmeno, string inPrijmeni, string inDatumNarozeni)
    {
        using (var DbContext = _dbContext)
        {
            if (DbContext.Students.Any(e => e.StudentId == inStudentId))
            {
                var newStudent = new Student
                { StudentId = inStudentId, Jmeno = inJmeno, Prijmeni = inPrijmeni, DatumNarozeni = inDatumNarozeni };

                DbContext.Students.Add(newStudent);
                DbContext.SaveChanges();
            }
            else
                Console.WriteLine($"Student s ID '{inStudentId}' uz existuje");
        }
    }

    // pridanie dat predmetu
    public void AddPredmetData(string inPredmetId, string inNazev)
    {
        using (var DbContext = new VyukaContext())
        {
            if (DbContext.Predmets.Any(e => e.PredmetId == inPredmetId))
            {
                var newPredmet = new Predmet
                { PredmetId = inPredmetId, Nazev = inNazev };

                DbContext.Predmets.Add(newPredmet);
                DbContext.SaveChanges();
            }
            else
                Console.WriteLine($"Predmet so skratkou '{inPredmetId}' uz existuje");
        }
    }

    public void AddStudentPredmetData(string inPredmetId, int inStudentId)
    {
        using (var DbContext = new VyukaContext())
        {
            if (DbContext.StudentPredmets.Any(e => e.PredmetId == inPredmetId && e.StudentId == inStudentId))
            {
                var newStudentPredmet = new StudentPredmet
                { PredmetId = inPredmetId, StudentId = inStudentId };

                DbContext.StudentPredmets.Add(newStudentPredmet);
                DbContext.SaveChanges();
            }
            else
                Console.WriteLine($"Student s ID '{inStudentId}' uz ma zapisany predmet '{inPredmetId}'");
        }
    }

    public void AddHodnoceniData(int inStudentId, string inPredmetId, string inDatum, int inZnamka)
    {
        using (var DbContext = new VyukaContext())
        {
            var newHodnoceni = new Hodnoceni
            { PredmetId = inPredmetId, StudentId = inStudentId, Datum = inDatum, Znamka = inZnamka };

            DbContext.Hodnocenis.Add(newHodnoceni);
            DbContext.SaveChanges();
        }
    }

    public void PrintPredmety()
    {
        using (var dbContext = _dbContext)
        {
            var subjectsStudentCounts = dbContext.Predmets
                .Select(s => new
                {
                    Subject = s,
                    StudentCount = dbContext.StudentPredmets.Count(e => e.PredmetId == s.PredmetId)
                })
                .OrderByDescending(x => x.StudentCount)
                .ToList();

            Console.WriteLine("Předměty s počty zapsaných studentů:");
            foreach (var item in subjectsStudentCounts)
            {
                Console.WriteLine($"Predmet: {item.Subject.Nazev}, Pocet studentov: {item.StudentCount}");
            }
        }
    }
}