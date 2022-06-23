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

        public string TurnOnPC()
        {
            _processor = new Processor();
            _processor.TurnOn();

            return "The PC is turned ON.";
        }

        public string TurnOnOS(OperatingSystem os)
        {
            if (_processor.IsTurnedOn)
            {
                _operatingSystem = os;
                _operatingSystem.TurnOn();

                return $"The {_operatingSystem} OS is turned ON.";
            }

            else
            {
                return "The OS cannot be turned ON.";
            }
        }

        public string TurnOnApplication()
        {
            if (_operatingSystem.IsTurnedOn)
            {
                _application = new Application();
                _application.TurnOn();

                return $"The Application is runned by {_operatingSystem}.";
            }
            return "";
        }

        public string TurnOffPC()
        {
            
            return "";
        }

        public string TurnOffOS()
        {
            if (_operatingSystem.IsTurnedOn)
            {
                if (_application.IsTurnedOn)
                {
                    _application.TurnOff();
                    _operatingSystem.TurnOff();

                    return "The application was forcibly turned OFF. The OS was turned OFF.";
                }

                else
                {
                    _operatingSystem.TurnOff();
                    return "The OS was turned OFF.";
                }
            }

            else
            {
                return "The OS is not turned ON.";
            }
        }

        public string TurnOffAplication()
        {
            if (_application.IsTurnedOn)
            {
                _application.TurnOff();
                return "The Application was turned OFF.";
            }

            else
            {
                return "The Application is not turned ON.";
            }
        }

    }
}
