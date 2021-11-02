using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Student.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Student.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IWebHostEnvironment _hostingEnvironment;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            IWebHostEnvironment environment)
        {
            _logger = logger;
            _hostingEnvironment = environment;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            

            using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory+ "Json/output.json"))
            {
                string json = r.ReadToEnd();
                IEnumerable<StudentVM> items = JsonConvert.DeserializeObject<IEnumerable<StudentVM>>(json);
                var List = items.SelectMany(x => x.class_details).GroupBy(x => x.subject_code).Select(x => x.FirstOrDefault()).ToList();

                var a = items.Select(x => new
                {
                    studentid = x.student_id,
                    class_details = x.class_details.FirstOrDefault(x => x.subject_code == "MGT5IPM")
                }).Where(x=>x.class_details !=null).ToList();
            }

            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            
        }
        public List<StudentVM> GetStudents(string subjectcode)
        {
            using (StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "Json/output.json"))
            {
                string json = r.ReadToEnd();
                IEnumerable<StudentVM> items = JsonConvert.DeserializeObject<IEnumerable<StudentVM>>(json);
                
            }
            return null;
        }

    }
}
