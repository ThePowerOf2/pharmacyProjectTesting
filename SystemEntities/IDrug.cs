using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemEntities {
    public interface IDrug {
        string DrugGMS { get; set; }
        string PropietaryName { get; set; }
        string GenericName { get; set; }
        double Cost { get; set; }
        string Manufacturer { get; set; }
        string Agent { get; set; }
    }
}