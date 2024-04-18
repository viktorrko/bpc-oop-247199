using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV11.EFCore
{
    public class Predmet
    {
        [Key] public string PredmetId { get; set; }
        public string Nazev {  get; set; }
    }
}
