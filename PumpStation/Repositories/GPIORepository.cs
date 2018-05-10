using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PumpStation.Repositories
{
    /// <summary>
    /// General interface for setting and/or getting pin values.
    /// 
    /// </summary>
    public interface IGPIORepository
    {
        int Get(int pinId);
        bool Set(int pinId, int value);
    }

    /// <summary>
    /// General class that should contain the HW spesific implementation for Get/Set.
    /// </summary>
    public class GPIORepository : IGPIORepository
    {
        public int Get(int pinId)
        {
            throw new NotImplementedException();
        }

        public bool Set(int pinId, int value)
        {
            throw new NotImplementedException();
        }
    }
}
