using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Chitic_Valentina_Web_App.Models
{
    public class Plant
    {
        public int ID { get; set; }

        [Required, StringLength(50, MinimumLength = 3)]
        [Display(Name = "Plant Name")]
        public string Name { get; set; }

        [Required, StringLength(1000, MinimumLength = 3)]

        public string Description { get; set; }

        [Range(1, 300)]
        [Column(TypeName ="decimal(6,2)")]
        public decimal Price { get; set; }

        [Display(Name = "Category")]
        public ICollection<PlantCategory> PlantCategories { get; set; }

        public int WeatherID { get; set; }
        public Weather Weather { get; set; }
        public int WateringID { get; set; }
        public Watering Watering { get; set; }


    }
}
