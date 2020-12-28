using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chitic_Valentina_Web_App.Models
{
    public class Watering
    {
        public int ID { get; set; }

        [Display(Name = "Watering Period")]
        public string WateringPer { get; set; }
        public ICollection<Plant> Plants { get; set; }
    }
}
