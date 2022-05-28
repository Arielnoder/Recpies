using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models;

namespace Recipes.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IWebHostEnvironment webHostEnvironment;


    public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
    {
        _logger = logger;
        this.webHostEnvironment = webHostEnvironment;
    }
   
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult AddRecipe()
    {
        List<RecipesModel> recipes = new List<RecipesModel>();
        using (var db = new RecipesContext())
        {
            recipes = db.RecipesModels.ToList();
        }
        TempData["Recipes"] = recipes;
        return View("AddRecipe");
    }

    public IActionResult Recipes() {
        List<RecipesModel> recipes = new List<RecipesModel>();
        using (var db = new RecipesContext())
        {
            recipes = db.RecipesModels.ToList();
        }
        TempData["Recipes"] = recipes;
        return View("Recipes");
    }
     [HttpPost]
    public IActionResult RemoveRecipe()
    {



        using (var db = new RecipesContext())
        {

            var recipe = db.RecipesModels.Where(u => u.Id >= 1).FirstOrDefault();
            if (recipe != null)
            {

                db.Remove(recipe);

                db.SaveChanges();

            }
            return RedirectToAction("Recipes");
        }


    }


    [HttpPost]
    public IActionResult AddRecipePost(RecipesModel recipe)
    {

            using (var db = new RecipesContext())
            {

            
                // Add file to wwwroot/images/
                string wwwrootPath = webHostEnvironment.WebRootPath;
                string fileName = recipe.ImageFile.FileName;
                string path = Path.Combine(wwwrootPath, "images", fileName);
                recipe.ImageName = fileName;
                recipe.ImageFile.CopyTo(new FileStream(path, FileMode.Create));
                  
                db.Add(recipe);
                db.SaveChanges();
                  




            }
            return RedirectToAction("AddRecipe");


    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
