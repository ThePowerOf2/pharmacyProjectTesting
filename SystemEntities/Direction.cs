using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEntities {
    public class Direction : IDirection {
        #region Direction Variables
        private string directions;
        private string drugGMS;
        private string prescriptionID;
        #endregion

        #region IDirection Variables
        public string Directions { get { return directions; } set { directions = value; } }
        public string DrugGMS { get { return drugGMS; } set { drugGMS = value; } }
        public string PrescriptionID { get { return prescriptionID; } set { prescriptionID = value; } }
        #endregion

        #region Constructors
        public Direction() {
            throw new System.NotImplementedException();
        }

        public Direction(string directions, string drugGMS, string prescriptionID) {
            this.directions = directions;
            this.drugGMS = drugGMS;
            this.prescriptionID = prescriptionID;
        }
        #endregion
    }
}
