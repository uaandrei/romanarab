using RomanNumbersCalculator.BL.NumberExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumbersCalculator.BL
{
    public class RomanNumberConverter
    {

        private int num;
        private static int[] numbers = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        private static String[] letters = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        public static string ToRoman(string arabicString)
        {
            var number = Convert.ToInt32(arabicString);
            if (number > 3999)
                throw new InvalidNumberException("Arabic is too large");
            var romanNumber = "";
            var remainingArabicNumber = number;

            for (int i = 0; i < numbers.Length; i++)
            {
                while (remainingArabicNumber >= numbers[i])
                {
                    romanNumber += letters[i];
                    remainingArabicNumber -= numbers[i];
                }
            }
            return romanNumber;
        }

        public static string ToArab(string romanString)
        {
            romanString = romanString.ToUpper();
            var i = 0;
            var arabicNumber = 0;
            while (i < romanString.Length)
            {
                var letter = romanString[i];
                var number = letterToNumber(letter);
                i++;
                if (i == romanString.Length)
                {
                    arabicNumber += number;
                }
                else
                {
                    var nextNumber = letterToNumber(romanString[i]);
                    if (nextNumber > number)
                    {
                        arabicNumber += (nextNumber - number);
                        i++;
                    }
                    else
                    {
                        arabicNumber += number;
                    }
                }
            }
            return arabicNumber.ToString();
        }

        private static int letterToNumber(char letter)
        {
            switch (letter)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
                default:
                    throw new InvalidNumberException("Invalid roman number");
            }
        }
    }
}
