using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.Validators
{
    public class BusinessValidator : Validator
    {
        public static string SprawdzVat(decimal? vat)
        {
            if (vat < 0 || vat > 100)
                return "VAT powinien byc z przedzialu od 0 do 100";
            return null;
        }
    }
}
