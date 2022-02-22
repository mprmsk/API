using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReactAPI.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "*")]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        public HttpResponseMessage Post(Energy energy)
        {

            

            List<Energy> obj = new List<Energy>();
            Energy energy1;
            for (int i = 0; i < 10; i++) {
                energy1 = new Energy();
                energy1.EnergyType = "Type " + i;
                obj.Add(energy1);
            }

            string rawJsonFromDb = JsonConvert.SerializeObject(obj);
            HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
            
            response.Content = new StringContent(rawJsonFromDb, Encoding.UTF8, "application/json");
            return response;


            
        }


    }
}
