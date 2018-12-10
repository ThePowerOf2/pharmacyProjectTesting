using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEntities {
    public interface IDirection {
        string Directions { get; set; }
        string DrugGMS { get; set; }
        string PrescriptionID { get; set; }
    }
}
