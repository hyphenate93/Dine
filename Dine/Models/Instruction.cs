using System.ComponentModel.DataAnnotations;

namespace Dine.Models
{
    public class Instruction
    {
        public int Id { get; set; }

        public int RecipeId { get; set; } // Foreign key to Recipes
        public Recipe Recipe { get; set; } // Navigation property for the Recipe

        public int StepNumber { get; set; }

        [Required]
        public string InstructionText { get; set; }
    }

}
