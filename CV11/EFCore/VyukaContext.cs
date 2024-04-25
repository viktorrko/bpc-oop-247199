using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CV11.EFCore
{
    public class VyukaContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Predmet> Predmets { get; set; }
        public DbSet<StudentPredmet> StudentPredmets { get; set; }
        public DbSet<Hodnoceni> Hodnocenis { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Student\Desktop\bpc-oop-247199\CV11\Vyuka.mdf;Integrated Security=True;Connect Timeout=30");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hodnoceni>().HasNoKey();
            modelBuilder.Entity<StudentPredmet>().HasNoKey();
        }

        public void AddStudent(string newJmeno, string newPrijmeni, string newDatumNarozeni)
        {
            if (true)
            {
                Students.Add(new Student { Jmeno = newJmeno, Prijmeni = newPrijmeni, DatumNarozeni = newDatumNarozeni });
                SaveChanges();
            }
        }

        public void AddPredmet(string newPredmetId, string newNazev)
        {
            if (true)
            {
                Predmets.Add(new Predmet { PredmetId = newPredmetId, Nazev = newNazev });
                SaveChanges();
            }
        }

        public void AddStudentPredmets(int newStudentId, string newPredmetId)
        {
            if (!StudentPredmets.Any())
            {
                StudentPredmets.Add(new StudentPredmet { PredmetId = newPredmetId, StudentId = newStudentId });
                SaveChanges();
            }
        }

        public void AddHodnoceni(int newStudentId, string PredmetId, string Datum, int Znamka)
        {
            Hodnocenis.Add(new Hodnoceni {  StudentId = newStudentId, PredmetId = PredmetId, Datum = Datum, Znamka = Znamka });
            SaveChanges();
        }

        public void PrintPredmets()
        {
            var query = from Predmet in Predmets
                        join StudentId in StudentPredmets
                        on Predmet.PredmetId equals StudentId into zapsaniGroup
                        select new
                        {
                            PredmetId = Predmet.PredmetId,
                            Pocet = zapsaniGroup.Count()
                        }
                        into result
                        orderby result.Pocet descending
                        select result;
            foreach(var item in query)
            {
                Console.WriteLine($"Premdet: {item.PredmetId}, Pocet: {item.Pocet}");
            }

        }

        public IEnumerable<Student> StudentiPredmetu(string predmetId)
        {
            var studentIds = from StudentPredmet in StudentPredmets
                           where StudentPredmet.PredmetId == predmetId
                           select StudentPredmet.StudentId;
            var studenti = from StudentId in Students
                           where studentIds.Contains(Student.StudentId)
                           select StudentId;

            return studenti.ToList();
        }

        public IEnumerable<Predmet> PredmetyStudenta(int studentId)
        {
            var predmetIds = from StudentPredmet in StudentPredmets
                             where StudentPredmet.StudentId == studentId
                             select StudentPredmet.PredmetId;

            var predmety = from Predmet in Predmets
                           where predmetIds.Contains(Predmet.PredmetId)
                           select Predmet;

            return predmety.ToList();
        }

        public void VypisPriemerneZnamky()
        {
            var query = from Predmet in Predmets
                        join Znamka in Hodnocenis on Predmet.PredmetId equals Znamka.PredmetId into hodnoceniGroup
                        select new
                        {
                            Predmet = Predmet,
                            Priemer = hodnoceniGroup.Average(h => h.Znamka)
                        };
            foreach (var item in query)
            {
                Console.WriteLine($"{item.Predmet}: {item.Priemer}");
            }
        }
    }
}
