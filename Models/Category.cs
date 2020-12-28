using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chitic_Valentina_Web_App.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        public ICollection<PlantCategory> PlantCategories { get; set; }
    }
}
