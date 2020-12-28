using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chitic_Valentina_Web_App.Models
{
    public class PlantData
    {
        public IEnumerable<Plant> Plants { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<PlantCategory> PlantCategories { get; set; }
    }
}
