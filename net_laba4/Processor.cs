using System;
using System.Collections.Generic;
using System.Text;

namespace net_laba4
{
    public class Processor
    {
        public bool IsTurnedOn { get; private set; }

        public void TurnOn()
        {
            IsTurnedOn = true;
        }

        public void TurnOff()
        {
            IsTurnedOn = false;
        }
    }
}
