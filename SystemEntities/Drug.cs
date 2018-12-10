using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEntities {
    public class Drug : IDrug {
        #region Drug Variables
        private string drugGMS;
        private string propietaryName;
        private string genericName;
        private double cost;
        private string manufacturer;
        private string agent;
        #endregion

        #region IDrug Variables
        public string DrugGMS { get {return drugGMS;} set{drugGMS = value;} }
        public string PropietaryName { get { return propietaryName;} set{propietaryName = value;} }
        public string GenericName { get { return genericName;} set{genericName = value;} }
        public double Cost { get { return cost;} set{cost = value;} }
        public string Manufacturer { get { return manufacturer;} set{ manufacturer = value;} }
        public string Agent { get { return agent;} set{agent = value;} }
        #endregion

        #region Constructors
        public Drug() {
            throw new System.NotImplementedException();
        }

        public Drug(string drugGMS, string propietaryName, string genericName, double cost, string manufacturer, string agent) {
            this.drugGMS = drugGMS;
            this.propietaryName = propietaryName;
            this.genericName = genericName;
            this.cost = cost;
            this.manufacturer = manufacturer;
            this.agent = agent;
        }
        #endregion
    }
}