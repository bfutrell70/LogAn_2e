using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LogAn.UnitTests
{
    public class MemCalculatorTests
    {
        [Test]
        public void Sum_ByDefault_ReturnsZero()
        {
            MemCalculator calculator = MakeCalc();

            int lastSum = calculator.Sum();

            Assert.That(lastSum, Is.EqualTo(0));
        }

        [Test]
        public void Add_WhenCalled_ChangesSum()
        {
            MemCalculator calculator = MakeCalc();

            calculator.Add(1);
            int sum = calculator.Sum();

            Assert.That(sum, Is.EqualTo(1));
        }

        private static MemCalculator MakeCalc()
        {
            return new MemCalculator();
        }
    }
}
