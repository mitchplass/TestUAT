using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUAT.Emulators.Drivers;
using TestUAT.Emulators.Types;

namespace TestUAT.Emulators.Helpers
{
    public class EmulatorWrapper
    {
        public static EmulatorVersions[] Versions => new[]
        {
            EmulatorVersions.Android8,
            EmulatorVersions.Android10,
            EmulatorVersions.Android11,
        };
    }
}
