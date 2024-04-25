using CV11.EFCore;
using Microsoft.EntityFrameworkCore;
using System;


using (VyukaContext dbContext = new VyukaContext())
{
    dbContext.Database.Migrate();

    dbContext.AddStudent("Zidan", "Motorku", "1995-01-01");
    dbContext.AddStudent("Damn", "Daniel", "1995-01-01");
    dbContext.AddStudent("Dreamy", "Bull", "1995-01-01");
    dbContext.AddPredmet("ELEA", "Elektro");
    dbContext.AddPredmet("BOOP", "Programko");
    dbContext.AddStudentPredmets(2, "BOOP");
    dbContext.AddStudentPredmets(2, "ELEA");
    dbContext.AddStudentPredmets(3, "ELEA");
    dbContext.AddStudentPredmets(4, "ELEA");
    dbContext.AddStudentPredmets(4, "BOOP");
    dbContext.AddHodnoceni(2, "BOOP", "2005-01-01", 90);
    dbContext.AddHodnoceni(2, "ELEA", "2005-01-01", 30);
    dbContext.AddHodnoceni(3, "ELEA", "2005-01-01", 80);
    dbContext.AddHodnoceni(3, "BOOP", "2005-01-01", 50);

}




