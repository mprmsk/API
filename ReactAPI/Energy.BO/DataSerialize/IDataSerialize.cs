using ReactAPI.Models;
using ReactAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactAPI.Energy1.BO.DataSerialize
{
    public interface IDataSerialize
    {
        public void DataSerializetoJson(string path, EnergyModel model);
        public List<EnergyModel> DataSerializeFromJson(string path);
    }
}
