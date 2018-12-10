using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEntities {
    public class Prescription : IPrescription {
        #region Prescription Variables
        private string prescriptionID;
        private DateTime date;
        private string staffUserName;
        private string doctorGMS;
        private string[] drugGMS;
        private Boolean repeatPrescription;
        private DateTime prescriptionEndDate;
        #endregion

        #region IPrescription Variables
        public string PrescriptionID { get { return prescriptionID; } set { prescriptionID = value; } }
        public DateTime Date { get { return date; } set { date = value; } }
        public string StaffUserName { get { return staffUserName; } set { staffUserName = value; } }
        public string DoctorGMS { get { return doctorGMS; } set { doctorGMS = value; } }
        public string[] DrugGMS { get { return drugGMS; } set { drugGMS = value; } }
        public Boolean RepeatPrescription { get { return repeatPrescription; } set { repeatPrescription = value; } }
        public DateTime PrescriptionEndDate { get { return prescriptionEndDate; } set { prescriptionEndDate = value; } }
        #endregion

        #region Constructors
        public Prescription() {
            throw new System.NotImplementedException();
        }

        public Prescription(string prescriptionID, DateTime date, string staffUserName, string doctorGMS, string[] drugGMS, bool repeatPrescription, DateTime prescriptionEndDate) {
            this.prescriptionID = prescriptionID;
            this.date = date;
            this.staffUserName = staffUserName;
            this.doctorGMS = doctorGMS;
            this.drugGMS = drugGMS;
            this.repeatPrescription = repeatPrescription;
            this.prescriptionEndDate = prescriptionEndDate;
        }


        #endregion
    }
}
