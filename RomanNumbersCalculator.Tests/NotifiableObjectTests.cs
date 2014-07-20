using CommonLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalculatorModule.Tests
{
    [TestClass]
    public class NotifiableObjectTests
    {
        [TestMethod]
        public void NotifyTriggers_When_PropertyIsSet()
        {
            var notifiableObject = new StubNotifiableObject();
            var hasTriggered = false;
            notifiableObject.PropertyChanged += (s, e) =>
            {
                hasTriggered = true;
            };
            notifiableObject.MyProperty = int.MaxValue;

            Assert.IsTrue(hasTriggered);
        }
    }

    class StubNotifiableObject : NotifiableObject
    {
        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set
            {
                NotifyPropertyChanged("MyProperty");
                myVar = value;
            }
        }

    }
}
