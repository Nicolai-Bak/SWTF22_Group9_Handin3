using System;
using Microwave.Classes.Interfaces;

namespace Microwave.Classes.Boundary
{
    public class PowerTube : IPowerTube
    {
        private IOutput _output;

        private bool _isOn = false;

        public int MaxPower { get; }

        public PowerTube(IOutput output, int maxPower)
        {
            _output = output;
            MaxPower = maxPower;
        }

        public void TurnOn(int power)
        {
            if (power < 1 || MaxPower < power)
            {
                throw new ArgumentOutOfRangeException("power", power, $"Must be between 1 and {MaxPower} (incl.)");
            }

            if (_isOn)
            {
                throw new ApplicationException("PowerTube.TurnOn: is already on");
            }

            _output.OutputLine($"PowerTube works with {power}");
            _isOn = true;
        }

        public void TurnOff()
        {
            if (_isOn)
            {
                _output.OutputLine($"PowerTube turned off");
            }

            _isOn = false;
        }
    }
}