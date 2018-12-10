using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEntities {
    public static class WarningFactory {
        private static IWarning theWarning = null;

        public static IWarning getWarning(string warningNo, string warning) {
            if (warning != null)
                return theWarning;
            else
                return new Warning(warningNo, warning);
        }
        public static void setUser(IWarning aWarning) {
            theWarning = aWarning;
        }
    }
}
