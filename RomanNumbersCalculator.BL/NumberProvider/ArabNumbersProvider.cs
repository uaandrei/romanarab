﻿using System.Collections.Generic;
using System.Linq;

namespace RomanNumbersCalculator.BL.NumberProvider
{
    public class ArabNumbersProvider : INumberProvider
    {
        private List<string> _arabNumbers = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };

        public List<string> Units
        {
            get { return _arabNumbers; }
        }

        public List<string> Tens
        {
            get { return _arabNumbers; }
        }

        public List<string> Thousands
        {
            get { return _arabNumbers.Take(4).ToList(); }
        }

        public List<string> Hundreds
        {
            get { return _arabNumbers; }
        }

        public string ZeroValue
        {
            get { return "0"; }
        }
    }
}