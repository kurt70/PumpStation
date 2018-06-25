using System;
using System.Collections.Generic;
using System.Text;

namespace CommonContracts
{
    public interface IHardwareAbstractionLayer
    {
        List<GPIOPin> GetPins();
        int Get(int pinId);
        void Set(int pinId, int value);
    }
}
