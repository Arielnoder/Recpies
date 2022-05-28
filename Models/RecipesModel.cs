using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
namespace Recipes.Models {
    public class RecipesModel {
 

    public int Id { get; set; }
    [Display(Name = "Recipe Name")]
    public string Name { get; set; }
    [Display (Name = "Recipe Ingredients")]
    public string ingredients { get; set; }
    [Display(Name = "Recipe Directions")]
    public string directions { get; set; }
    [Display(Name = "Recipe Category")]
    public string category { get; set; }
    [Display(Name = "Recipe Discription")]
    public string description { get; set; }

    public string ImageName { get; set; }

    [NotMapped]
    [Display(Name = "Upload Image")]
     public IFormFile ImageFile { get; set; }




}
}