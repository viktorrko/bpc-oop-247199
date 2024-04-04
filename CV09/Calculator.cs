using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV09
{


    internal class Calculator
    {
        public string Display = "";
        public string Pamet = "";
        private string Operation = "+";
        private double PrveCislo = 0;
        private double DruheCislo = 0;
        private double Vysledok = 0;
        private enum Stav
        {
            PrvniCislo,
            Operace,
            DruheCislo,
            Vysledek
        };
        Stav _stav;

        public Calculator()
        {
            Stav _stav = Stav.PrvniCislo;
        }

        
        private void Calculate()
        {
            switch(Operation)
            {
                case "+":
                    Vysledok = PrveCislo + DruheCislo; break;
                case "-":
                    Vysledok = PrveCislo - DruheCislo; break;
                case "*":
                    Vysledok = PrveCislo * DruheCislo; break;
                case "/":
                    Vysledok = PrveCislo / DruheCislo; break;
            }
        }

        public void Tlacitko(string s)
        {
            // rozhodovanie na zaklade _stav
            switch (_stav)
            {
                case Stav.PrvniCislo:
                    ActionsPrvniCislo(s); break;

                case Stav.Operace:
                    ActionsOperace(s); break;

                case Stav.DruheCislo:
                    ActionsDruheCislo(s); break;

                case Stav.Vysledek:
                    ActionsVysledek(s); break;
            }
        }

        private void ActionsVysledek(string s)
        {
            switch (s)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                case ",":
                    Display = s; _stav = Stav.PrvniCislo; break;
                case "back":
                    Display = ""; _stav = Stav.PrvniCislo; break;
                case "CE":
                    Display = ""; _stav = Stav.PrvniCislo; break;
                case "MC":
                    Pamet = ""; break;
                case "MR":
                    Display = Pamet; break;
                case "M+":
                    Pamet = (Double.Parse(Pamet) + Double.Parse(Display)).ToString(); break;
                case "M-":
                    Pamet = (Double.Parse(Pamet) - Double.Parse(Display)).ToString(); break;
                case "MS":
                    Pamet = Display; break;
                default:
                    Console.WriteLine("Operator nema v tomto rezime ziadnu funkciu."); break;
            }
        }

        private void ActionsDruheCislo(string s)
        {
            switch (s)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                case ",":
                    Display += s; break;
                case "back":
                    Display = Display.Remove(Display.Length - 1); break;
                case "=":
                    DruheCislo = Double.Parse(Display);
                    Calculate();
                    Display = Vysledok.ToString();
                    _stav = Stav.Vysledek;
                    break;
                case "CE":
                    Display = ""; _stav = Stav.PrvniCislo; break;
                case "MC":
                    Pamet = ""; break;
                case "MR":
                    Display = Pamet; break;
                case "M+":
                    Pamet = (Double.Parse(Pamet) + Double.Parse(Display)).ToString(); break;
                case "M-":
                    Pamet = (Double.Parse(Pamet) - Double.Parse(Display)).ToString(); break;
                case "MS":
                    Pamet = Display; break;
                default:
                    Console.WriteLine("Operator nema v tomto rezime ziadnu funkciu."); break;
            }
        }

        private void ActionsOperace(string s)
        {
            switch (s)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                case ",":
                    Display = s; _stav = Stav.DruheCislo; break;
                case "+":
                case "-":
                case "*":
                case "/":
                    Display = s; Operation = s; break;
                case "CE":
                    Display = ""; _stav = Stav.PrvniCislo; break;
                default:
                    Console.WriteLine("Operator nema v tomto rezime ziadnu funkciu."); break;
            }
        }

        private void ActionsPrvniCislo(string s)
        {
            switch (s)
            {
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                case "0":
                case ",":
                    Display += s; break;
                case "back":
                    Display = Display.Remove(Display.Length - 1); break;
                case "+":
                case "-":
                case "*":
                case "/":
                    PrveCislo = Double.Parse(Display);
                    Display = s; Operation = s;
                    _stav = Stav.Operace;
                    break;
                case "=":
                    Calculate();
                    Display = Vysledok.ToString();
                    _stav = Stav.Vysledek;
                    break;
                case "CE":
                    Display = ""; _stav = Stav.PrvniCislo; break;
                case "MC":
                    Pamet = ""; break;
                case "MR":
                    Display = Pamet; break;
                case "M+":
                    Pamet = (Double.Parse(Pamet) + Double.Parse(Display)).ToString(); break;
                case "M-":
                    Pamet = (Double.Parse(Pamet) - Double.Parse(Display)).ToString(); break;
                case "MS":
                    Pamet = Display; break;
                default:
                    Console.WriteLine("Operator nema v tomto rezime ziadnu funkciu."); break;
            }
        }
    }
}