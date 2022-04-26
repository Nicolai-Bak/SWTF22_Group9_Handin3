using System.Threading;
using Microwave.Classes.Interfaces;

namespace Microwave.Classes.Boundary
{
    public class Buzzer : IBuzzer
    {
        private readonly IOutput _output; 
        public Buzzer(IOutput output)
        {
            _output = output;
        }
        public void BuzzThreeTimes()
        {
            for (int i = 0; i < 3; i++)
            {
                _output.OutputLine("Buuuzz");
                Thread.Sleep(1000);
            }
        }

        public void BuzzShort()
        {
            _output.OutputLine("Buzz");
        }
    }
}