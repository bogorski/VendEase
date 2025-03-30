using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.Validators
{
    public class StringValidator : Validator
    {
        public static string SprawdzCzyZaczynaSieOdDuzej(string wartosc)
        {
            try
            {
                if (!char.IsUpper(wartosc, 0))
                    return "Rozpocznij dużą literą";
            }
            catch (Exception e) { }
                return null;
                //funkcja zwraca komunikat z bledem, a jak błedu brak to zwraca null
        }
    }
}
