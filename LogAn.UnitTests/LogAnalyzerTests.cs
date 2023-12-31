using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace LogAn.UnitTests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        private LogAnalyzer MakeAnalyzer()
        {
            return new LogAnalyzer();
        }

        [Test]
        public void IsValidLogFileName_BadExtension_ReturnsFalse()
        {
            // arrange
            LogAnalyzer analyzer = new LogAnalyzer();

            // act
            bool result = analyzer.IsValidLogFileName("filenamewithbadextension.foo");

            // assert
            Assert.That(result, Is.False);
        }

        [TestCase("filenamewithgoodextension.slf")]
        [TestCase("filenamewithgoodextension.SLF")]
        public void IsValidLogFileName_ValidExtensions_ReturnsTrue(string file)
        {
            LogAnalyzer analyzer = new LogAnalyzer();

            bool result = analyzer.IsValidLogFileName(file);

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsValidFileName_EmptyFileName_Throws()
        {
            LogAnalyzer la = MakeAnalyzer();

            var ex = Assert.Throws<ArgumentException>(() => la.IsValidLogFileName(""));

            StringAssert.Contains("filename has to be provided", ex!.Message);
            //Assert.That(ex!.Message, Is.EqualTo("filename has to be provided"));
        }

        [TestCase("badname.foo", false)]
        [TestCase("goodname.slf", true)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid(string file, bool expected)
        {
            LogAnalyzer la = MakeAnalyzer();

            la.IsValidLogFileName(file);

            Assert.That(la.WasLastFileNameValid, Is.EqualTo(expected));
        }
    }
}
