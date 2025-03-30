using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VendEase.Models.Validators
{
    public class RegistrationNumberValidator : Validator
    {
        public static string SprawdzNumerRejestracyjny(string numerRejestracyjny)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(numerRejestracyjny))
                {
                    return "Numer rejestracyjny nie może być pusty.";
                }

                if (numerRejestracyjny.Any(c => char.IsLower(c)))
                {
                    return "Numer rejestracyjny może zawierać tylko wielkie litery.";
                }

                numerRejestracyjny = numerRejestracyjny.Replace(" ", "");

               // string pattern = @"^[A-Z]{1}[A-Z0-9]{3,6}$";
                string pattern = @"^[A-Z]{1}[A-Z0-9]{0,2}\s?[A-Z0-9]{3,4}$";

                if (!Regex.IsMatch(numerRejestracyjny, pattern))
                {
                    return "Numer rejestracyjny jest niepoprawny.";
                }
            }
            catch (Exception e) { }
            return null;
        }
    }
}
