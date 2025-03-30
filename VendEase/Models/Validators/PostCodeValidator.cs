using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VendEase.Models.Validators
{
    public class PostCodeValidator : Validator
    {
        public static string SprawdzCzyPoprawnyKodPocztowy(string wartosc)
        {
            try
            {
                string pattern = @"^\d{2}-\d{3}$";
                if (!Regex.IsMatch(wartosc, pattern))
                    return "Podaj poprawny kod pocztowy. Format kodu NN-NNN";
            }
            catch (Exception e) { }
            return null;
        }
    }
}
