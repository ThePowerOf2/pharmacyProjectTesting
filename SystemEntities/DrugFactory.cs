using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEntities {
    public static class DrugFactory {
        private static IDrug drug = null;

        public static IDrug getDrug(string drugGMS, string propietaryName, string genericName, double cost, string manufacturer, string agent) {
            if (drug != null)
                return drug;
            else
                return new Drug(drugGMS, propietaryName, genericName, cost, manufacturer, agent);
        }

        public static void setDrug(IDrug aDrug) {
            drug = aDrug;
        }
    }
}