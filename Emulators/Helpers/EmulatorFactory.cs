using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUAT.Emulators.Drivers;
using TestUAT.Emulators.Types;

namespace TestUAT.Emulators.Helpers
{
    public static class EmulatorFactory
    {
        public static void StartDriver(EmulatorVersions version)
        {
            switch (version)
            {
                case EmulatorVersions.Android8:
                    break;
                case EmulatorVersions.Android10:
                    new Android10().StartDriver();
                    break;
                case EmulatorVersions.Android11:
                    break;
                default:
                    break;
            };
        }
    }
}
