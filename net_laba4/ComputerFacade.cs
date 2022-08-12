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
                return _processor != null && _processor.IsTurnedOn;
            }
        }

        private bool ApplicationIsTurnedOn
        {
            get
            {
                return _application != null && _application.IsTurnedOn;
            }
        }

        private bool OperatingSystemIsTurnedOn
        {
            get
            {
                return _operatingSystem != null && _operatingSystem.IsTurnedOn;
            }
        }

        public SystemResult TurnOnPC()
        {
            SystemResult result = new SystemResult();

            _processor = new Processor();
            _processor.TurnOn();

            result.Result = "The PC was turned ON.";
            result.Succeed = true;
            return result;
        }

        public SystemResult TurnOnOS(OperatingSystem os)
        {
            SystemResult result = new SystemResult();

            if (ProcessorIsTurnedOn)
            {
                _operatingSystem = os;
                _operatingSystem.TurnOn();
                result.Result = "The OS was turned ON.";
                result.Succeed = true;
                return result;
            }

                result.Result = "The OS was not turned ON.";
                result.Succeed = false;
                return result;
        }

        public SystemResult TurnOnApplication()
        {
            SystemResult result = new SystemResult();

            if(OperatingSystemIsTurnedOn)
            {
                _application = new Application();
                _application.TurnOn();
                result.Result = "The application was turned ON.";
                result.Succeed = true;
                return result;
            }

                result.Result = "The OS is not turned ON so you can`t start your application.";
                result.Succeed = false;
                return result; 
        }

        public SystemResult TurnOffPC()
        {
            StringBuilder builder = new StringBuilder();
            SystemResult result = new SystemResult();

            if (ProcessorIsTurnedOn)
            {
                if (OperatingSystemIsTurnedOn)
                    builder.AppendLine(TurnOffOS().Result);

                _processor.TurnOff();
                builder.AppendLine("The Processor was turned OFF.");

                result.Result = builder.ToString();
                result.Succeed = true;
                return result;
            }

                result.Result = "The PC can`t be turned OFF.";
                result.Succeed = false;
                return result;
        }

        public SystemResult TurnOffOS()
        {
            StringBuilder builder = new StringBuilder();
            SystemResult result = new SystemResult();

            if (OperatingSystemIsTurnedOn)
            {
                if (ApplicationIsTurnedOn)
                {
                    _application.TurnOff();
                    builder.AppendLine("The application was forcibly turned OFF. ");
                }

                _operatingSystem.TurnOff();
                builder.AppendLine("The OS was turned OFF.");

                result.Result = builder.ToString();
                result.Succeed = true;
                return result;
            }

                result.Result = "The OS can`t be turned OFF.";
                result.Succeed = false;
                return result;
        }

        public SystemResult TurnOffApplication()
        {
            SystemResult result = new SystemResult();
            if (ApplicationIsTurnedOn)
            {
                _application.TurnOff();
                result.Result = "The application was turned OFF.";
                result.Succeed = true;
                return result;
            }
            
                result.Result = "The application can`t be turned OFF.";
                result.Succeed = false;
                return result;
        }
    }
}
