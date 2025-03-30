using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendEase.Models.Validators
{
    public class NIPValidator : Validator
    {
        public static string SprawdzNIP(string NIP)
        {
                if (string.IsNullOrEmpty(NIP))
                {
                    return "NIP nie może być pusty";
                }

                NIP = NIP.Replace(" ", "").Replace("-", "");

                if (NIP.Length != 10)
                {
                    return "NIP musi składać się z 10 cyfr";
                }

                int[] NIPArray = new int[10];
                for (int i = 0; i < 10; i++)
                {
                    NIPArray[i] = int.Parse(NIP[i].ToString());
                }

                //wagi cyfr
                int[] weights = new int[] { 6, 5, 7, 2, 3, 4, 5, 6, 7 };
                int sum = 0;

                for (int i = 0; i < 9; i++)
                {
                    sum += NIPArray[i] * weights[i];
                }

                int controlDigit = sum % 11;

                //cyfra kontrolna = ostatnia cyfra NIP
                if (controlDigit != NIPArray[9])
                    return "NIP jest niepoprawny";
                return null;
        }
    }
}
