using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Recipes.Models
{
    public class RecipesContext : DbContext
    {
        
        public DbSet<RecipesModel> RecipesModels {get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder options) 
            =>options.UseSqlite(@"Data Source=Recipes.db");
        
    }
}