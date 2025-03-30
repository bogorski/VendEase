using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.Validators
{
    public class QuantityValidator : Validator
    {
        public static string SprawdzCzyPowyzejZera(decimal? ilosc)
        {
            if (ilosc <= 0)
                return "Wartość musi być większa niż 0";
            return null;
        }

        public static string SprawdzCzyWiekszeRowneZero(decimal? ilosc)
        {
            if (ilosc < 0)
                return "Wartość nie może być mniejsza niż 0";
            return null;
        }
    }
}
