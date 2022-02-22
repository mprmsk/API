using ReactAPI.DateCalcBusinessObjects;
using ReactAPI.Energy1.BO.DataSerialize;
using ReactAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ReactAPI.Models;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace ReactAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnergyController : ControllerBase
    {
        private readonly IEnergyCalcBO energy;
        private readonly IDataSerialize dataSerialize;
        private readonly string path = @"D:\Temp.json";

        public EnergyController(IEnergyCalcBO _energy, IDataSerialize _dataSerialize)
        {
            this.energy = _energy;
            this.dataSerialize = _dataSerialize;
        }
        [HttpGet]
        public IList<EnergyModel> Get()
        {
            return this.dataSerialize.DataSerializeFromJson(path);
        }

        [HttpPost]
        public HttpResponseMessage Post(EnergyModel model)
        {
            List<EnergyModel> listDetails = new List<EnergyModel>();
             if (this.energy.CalculateWeekEnd(model.EnteredDate))
            {
                model.Cost = model.Cost / 10;
            }

            this.dataSerialize.DataSerializetoJson(path, model);
            HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);            
            return response;
        }

    }

}
