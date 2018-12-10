using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEntities {
    public interface IDoctor {
        string DoctorGMS { get; set; }
        string FirstName { get; set; }
        string SecondName { get; set; }
        string Address { get; set; }
        string ContactNo { get; set; }
    }
}
