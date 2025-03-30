using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.Validators
{
    public class DateValidator : Validator
    {
        public static string SprawdzCzyDataJestPrzedDzis(DateTime? data)
        {
            if (DateTime.Now <= data)
                return "Data musi być sprzed dzisiejszego dnia";
            return null;
        }
    }
}
