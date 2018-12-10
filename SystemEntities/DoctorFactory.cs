using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEntities {
    public static class DoctorFactory {
        public static IDoctor doctor = null;

        public static IDoctor getDoctor(string doctorGMS, string firstName, string secondName, string address, string contactNo) {
            if (doctor != null)
                return doctor;
            else
                return new Doctor(doctorGMS, firstName, secondName, address, contactNo);
        }

        public static void setDoctor(IDoctor aDoctor) {
            doctor = aDoctor;
        }
    }
}
