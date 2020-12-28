using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chitic_Valentina_Web_App.Models
{
    public class Weather
    {
        public int ID { get; set; }

        [Display(Name = "Weather Type")]
        public string WeatherType { get; set; }
        public ICollection<Plant> Plants { get; set; }
    }
}
