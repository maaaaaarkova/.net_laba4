﻿using System;
using net_laba4.OS;

namespace net_laba4
{
    class Program
    {
        static void Main()
        {
            ComputerFacade facade = new ComputerFacade();

            var pcTurnOn = facade.TurnOnPC();
            Console.WriteLine(pcTurnOn);

            Console.WriteLine("\n");

            var applicationTurnOnFailed = facade.TurnOnApplication();
            Console.WriteLine(applicationTurnOnFailed);

            Console.WriteLine("\n");

            OperatingSystem os = new LinuxOS();
            var OSTurnOn = facade.TurnOnOS(os);
            Console.WriteLine(OSTurnOn);

            Console.WriteLine("\n");

            var applicationTurnOn = facade.TurnOnApplication();
            Console.WriteLine(applicationTurnOn);

            Console.WriteLine("\n");

            var OSTurnOff = facade.TurnOffOS();
            Console.WriteLine(OSTurnOff);

            var pcTurnOff = facade.TurnOffPC();
            Console.WriteLine(pcTurnOff);


        }
    }
}
