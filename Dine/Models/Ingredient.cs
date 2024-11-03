using System.ComponentModel.DataAnnotations;

namespace Dine.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        public int RecipeId { get; set; } // Foreign key to Recipes
        public Recipe Recipe { get; set; } // Navigation property for the Recipe

        [Required]
        public string Name { get; set; }

        public string Quantity { get; set; }
        public string Unit { get; set; }
    }

}
