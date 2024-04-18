using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Database=Vyuka");
        }




    }

    

    
}
