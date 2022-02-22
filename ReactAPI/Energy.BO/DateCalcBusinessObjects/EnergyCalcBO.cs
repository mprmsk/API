using ReactAPI.DateCalcBusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactAPI.DateCalcBusinessObjects
{
    public class EnergyCalcBO : IEnergyCalcBO
    {
        public bool CalculateWeekEnd(DateTime date)
        {
            return (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday) ? true : false;
        }
    }
}
