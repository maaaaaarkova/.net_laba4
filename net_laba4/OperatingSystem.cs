using System;
using System.Collections.Generic;
using System.Text;

namespace net_laba4
{
    public abstract class OperatingSystem
    {
        public string Name { get; protected set; }

        public bool IsTurnedOn { get; protected set; }

        public virtual void TurnOn()
        {
            IsTurnedOn = true;

        }

        public virtual void TurnOff()
        {
            IsTurnedOn = false;
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
