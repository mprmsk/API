using ReactAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ReactAPI.DateCalcBusinessObjects;
using ReactAPI.Energy1.BO.DataSerialize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReactAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ReactController : ControllerBase
    {
        

        private readonly IEnergyCalcBO energy;
        private readonly IDataSerialize dataSerialize;
        private readonly string path = @"C:\Temp.json";

        public ReactController(IEnergyCalcBO _energy, IDataSerialize _dataSerialize)
        {
            this.energy = _energy;
            this.dataSerialize = _dataSerialize;
        }
        [HttpGet]
        public IList<EnergyModel> Get()
        {
            return this.dataSerialize.DataSerializeFromJson(path);
        }

    }
}
