using ReactAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactAPI.DateCalcBusinessObjects
{
    public interface IEnergyCalcBO
    {
        public bool CalculateWeekEnd(DateTime date);
    }
}
