using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Dine.Data;
using Microsoft.AspNetCore.Identity;

namespace Dine.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        public string ImageUrl { get; set; }

        // Use string for OwnerId since the AspNetUsers table uses string (GUID) for the primary key
        public string OwnerId { get; set; } // Foreign key to AspNetUsers

        // Reference the ApplicationUser class here instead of IdentityUser
        public ApplicationUser Owner { get; set; } // Navigation property for the user

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Navigation properties
        public ICollection<Ingredient> Ingredients { get; set; }
        public ICollection<Instruction> Instructions { get; set; }
    }
}
