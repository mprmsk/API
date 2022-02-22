using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactAPI.Models
{
    public class EnergyModel
    {
        public int id { get; set; }
        public DateTime EnteredDate { get; set; }
        public string Energy { get; set; }
        public double Cost { get; set; }
    }
}
