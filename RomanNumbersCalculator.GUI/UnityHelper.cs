using Microsoft.Practices.Unity;
using RomanNumbersCalculator.BL.NumberProvider;
using RomanNumbersCalculator.BL.RomanNumberSpecification;
using RomanNumbersCalculator.BL.StringNumberParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumbersCalculator.GUI
{
    class UnityHelper
    {
        private static UnityHelper _instance;
        private IUnityContainer _unityContainer;

        public static UnityHelper Instance
        {
            get
            {
                _instance = _instance ?? new UnityHelper();
                return _instance;
            }
        }

        public IUnityContainer UnityContainer { get { return _unityContainer; } }

        private UnityHelper()
        {
            _unityContainer = new UnityContainer();
            _unityContainer.RegisterType<IStringNumberParser, RomanStringParser>();
            _unityContainer.RegisterType<ISpecification<string>, ConsecutiveRomanPositionalsMustBeDescendingAndUnique>();
            _unityContainer.RegisterType<INumberProvider, RomanNumbersProvider>();
        }
    }
}
