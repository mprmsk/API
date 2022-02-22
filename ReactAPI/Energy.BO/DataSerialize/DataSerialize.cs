using ReactAPI.Models;
using Newtonsoft.Json;
using ReactAPI.Energy1.BO.DataSerialize;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace React.Energy.BO.DataSerialize
{
    public class DataSerialize : IDataSerialize
    {
        public List<EnergyModel> DataSerializeFromJson(string path)
        {
            return GetFromFile(path);
        }

        public void DataSerializetoJson(string path, EnergyModel model)
        {
            try
            {
                List<EnergyModel> models = GetFromFile(path);
                model.id = models.Count + 1;
                models.Add(model);
                TextWriter writer;
                using (writer = new StreamWriter(path, append: false))
                {
                    writer.WriteLine(JsonConvert.SerializeObject(models));
                }
            }
            catch (Exception Ex)
            {
                throw;
            }
        }
        private List<EnergyModel> GetFromFile(string path)
        {
            List<EnergyModel> listmodels = new List<EnergyModel>();
            if (File.Exists(path))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(path))
                    {
                        listmodels = JsonConvert.DeserializeObject<List<EnergyModel>>(reader.ReadToEnd());
                    }
                }
                catch (Exception ex)
                {
                    //throw;
                }
            }
            return listmodels;
        }
    }
}
