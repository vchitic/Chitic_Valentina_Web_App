using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Chitic_Valentina_Web_App.Data;


namespace Chitic_Valentina_Web_App.Models
{
    public class PlantCategoriesModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Chitic_Valentina_Web_AppContext context, Plant plant)
        {
            var allCategories = context.Category;
            var plantCategories = new HashSet<int>(
            plant.PlantCategories.Select(c => c.CategoryID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = plantCategories.Contains(cat.ID)
                });
            }
        }
        public void UpdatePlantCategories(Chitic_Valentina_Web_AppContext context, string[] selectedCategories, Plant plantToUpdate)
        {
            if (selectedCategories == null)
            {
                plantToUpdate.PlantCategories = new List<PlantCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var plantCategories = new HashSet<int>
            (plantToUpdate.PlantCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!plantCategories.Contains(cat.ID))
                    {
                        plantToUpdate.PlantCategories.Add(
                        new PlantCategory
                        {
                            PlantID = plantToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (plantCategories.Contains(cat.ID))
                    {
                        PlantCategory courseToRemove
                        = plantToUpdate
                        .PlantCategories
                        .SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
