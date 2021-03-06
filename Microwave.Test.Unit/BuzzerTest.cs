using Microwave.Classes.Boundary;
using Microwave.Classes.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace Microwave.Test.Unit
{
    [TestFixture]
    public class BuzzerTest
    {
        private Buzzer uut;
        private IOutput output;

        [SetUp]
        public void Setup()
        {
            output = Substitute.For<IOutput>();

            uut = new Buzzer(output);
        }

        [Test]
        public void BuzzThreeTimes_CorrectOutput()
        {
            uut.BuzzThreeTimes();
            output.Received(3).OutputLine(Arg.Is<string>(str => str.Contains("Buuuzz")));
        }
        
        [Test]
        public void BuzzShort_CorrectOutput()
        {
            uut.BuzzShort();
            output.Received(1).OutputLine(Arg.Is<string>(str => str.Contains("Buzz")));
        }
    }
}