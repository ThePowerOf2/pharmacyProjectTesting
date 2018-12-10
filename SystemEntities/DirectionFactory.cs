using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEntities {
    public static class DirectionFactory {
        private static IDirection direction = null;

        public static IDirection getDirection(string directions, string drugGMS, string prescriptionID) {
            if (direction != null)
                return direction;
            else
                return new Direction(directions, drugGMS, prescriptionID);
        }

        public static void setUser(IDirection aDirection) {
            direction = aDirection;
        }
    }
}
