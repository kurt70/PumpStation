using System;
using System.Collections.Generic;
using System.Text;

namespace CommonContracts
{
    public class GPIOPin
    {
        public int PinNumber { get; set; }
        public PinDirection Direction { get; set; }
        public int? Value { get; set; }
    }
}
