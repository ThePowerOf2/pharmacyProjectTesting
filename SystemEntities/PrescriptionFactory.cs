using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEntities {
    public static class PrescriptionFactory {
        private static IPrescription prescription = null;

        public static IPrescription getPrescription(string prescriptionID, DateTime date, string staffUserName, string doctorGMS, string[] drugGMS, bool repeatPrescription, DateTime prescriptionEndDate) {
            if (prescription != null)
                return prescription;
            else
                return new Prescription(prescriptionID,date,staffUserName,doctorGMS,drugGMS,repeatPrescription,prescriptionEndDate);
        }
        public static void setUser(IPrescription aPrescription) {
            prescription = aPrescription;
        }
    }
}
