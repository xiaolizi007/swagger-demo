using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Swagger.Demo.Controllers
{
    /// <summary>
    /// Weather Controller responsible for GET/POST for managing weather
    /// </summary>
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

        /// <summary>
        /// This GET method returns fake weather
        /// </summary>
        /// <returns>An array of weather forecast</returns>
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
        
             /// <summary>
        /// 这是一个api测试
        /// </summary>
        /// <param name="id">用户的id</param>
        /// <returns>一个字符串</returns>
        /// <remarks>下面的httpget是必须项，否则swagger无法显示</remarks>
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "1";
        }
    }
}
