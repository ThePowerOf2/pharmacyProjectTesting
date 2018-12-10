using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEntities {
    public interface IPrescription {
        string PrescriptionID { get; set; }
        DateTime Date { get; set; }
        string StaffUserName { get; set; }
        string DoctorGMS { get; set; }
        string[] DrugGMS { get; set; }
        Boolean RepeatPrescription { get; set; }
        DateTime PrescriptionEndDate { get; set; }
    }
}
