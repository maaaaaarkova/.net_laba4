using System;
using System.Collections.Generic;
using System.Text;

namespace net_laba4
{
    public class ComputerFacade
    {
        private Processor _processor;
        private Application _application;
        private OperatingSystem _operatingSystem;

        private bool ProcessorIsTurnedOn
        {
            get
            {
                return _processor == null ? false : _processor.IsTurnedOn;
            }
        }

        private bool ApplicationIsTurnedOn
        {
            get
            {
                return _application == null ? false : _application.IsTurnedOn;
            }
        }

        private bool OperatingSystemIsTurnedOn
        {
            get
            {
                return _operatingSystem == null ? false : _operatingSystem.IsTurnedOn;
            }
        }

        public bool TurnOnPC()
        {
            _processor = new Processor();
            _processor.TurnOn();

            return _processor.IsTurnedOn;
        }

        public bool TurnOnOS(OperatingSystem os)
        {
            if (ProcessorIsTurnedOn)
            {
                _operatingSystem = os;
                _operatingSystem.TurnOn();
            }

            return _operatingSystem.IsTurnedOn;
        }

        public bool TurnOnApplication()
        {
            bool osIsTurnedOn = _operatingSystem == null ? false : _operatingSystem.IsTurnedOn;

            if (osIsTurnedOn)
            {
                _application = new Application();
                _application.TurnOn();

            }

            return _application.IsTurnedOn;  
        }

        public string TurnOffPC()
        {
            StringBuilder builder = new StringBuilder();

            if (ProcessorIsTurnedOn)
            {
                if (OperatingSystemIsTurnedOn)
                    builder.AppendLine(TurnOffOS());

                _processor.TurnOff();
                builder.AppendLine("The Processor was turned OFF.");

                return builder.ToString();
            }


            return "The PC is already turned OFF"; 
        }

        public string TurnOffOS()
        {
            StringBuilder builder = new StringBuilder();

            if (OperatingSystemIsTurnedOn)
            {
                if (ApplicationIsTurnedOn)
                {
                    _application.TurnOff();
                    builder.AppendLine("The application was forcibly turned OFF. ");
                }

                _operatingSystem.TurnOff();
                builder.AppendLine("The OS was turned OFF.");

                return builder.ToString();
            }

            return "The OS is not turned ON.";
        }

        public bool TurnOffAplication()
        {
            if (ApplicationIsTurnedOn)
            {
                _application.TurnOff();
            }

            return _application.IsTurnedOn;
        }

    }
}
