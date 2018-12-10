using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEntities {
    public class Doctor : IDoctor {
        #region Doctor Variables
        private string doctorGMS;
        private string firstName;
        private string secondName;
        private string address;
        private string contactNo;
        #endregion

        #region IDoctor Variables
        public string DoctorGMS { get { return doctorGMS; } set { doctorGMS = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string SecondName { get { return firstName; } set { secondName = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string ContactNo { get { return contactNo} set { contactNo = value; } }
        #endregion

        #region Constructors
        public Doctor() {
            throw new System.NotImplementedException();
        }

        public Doctor(string doctorGMS, string firstName, string secondName, string address, string contactNo) {
            this.doctorGMS = doctorGMS;
            this.firstName = firstName;
            this.secondName = secondName;
            this.address = address;
            this.contactNo = contactNo;
        }
        #endregion
    }
}