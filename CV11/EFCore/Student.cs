﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV11.EFCore
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public string DatumNarozeni { get; set; }
    }
}
