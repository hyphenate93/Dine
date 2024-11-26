using Dine.Data;
using Dine.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace Dine.Services
{
    public class RecipeService
    {
        private readonly ApplicationDbContext _context;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public RecipeService(ApplicationDbContext context, AuthenticationStateProvider authenticationStateProvider)
        {
            _context = context;
            _authenticationStateProvider = authenticationStateProvider;
        }

        // Method to create a new recipe
        public async Task<bool> CreateRecipeAsync(Recipe recipe)
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();

            var user = authState.User;
            if (user == null)
            {
                return false;
            }
            if (user.Identity == null)
            {
                return false;
            }
            // Ensure the user is authenticated
            if (user.Identity.IsAuthenticated)
            {
                return false;
            }

            // Find the logged-in user's ID
            var userId = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userId == null)
            {
                return false;
            }
            // Assign the OwnerId to the logged-in user's ID
            recipe.OwnerId = userId;

            // Add any new ingredients to the database if they don't exist yet
            foreach (var ingredient in recipe.Ingredients)
            {
                var existingIngredient = await _context.Ingredients
                    .FirstOrDefaultAsync(i => i.Name.ToLower() == ingredient.Name.ToLower());

                if (existingIngredient == null)
                {
                    // If the ingredient doesn't exist, add it to the context and link to the recipe
                    _context.Ingredients.Add(ingredient);
                }
                else
                {
                    // Link the existing ingredient to the recipe
                    ingredient.Id = existingIngredient.Id;
                }
            }

            // Add the recipe and save changes to the database
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AddIngredientIfNotExistAsync(string ingredientName)
        {
            var existingIngredient = await _context.Ingredients.FirstOrDefaultAsync(i => i.Name == ingredientName);
            if (existingIngredient == null)
            {
                _context.Ingredients.Add(new Ingredient { Name = ingredientName });
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        // Method to get recipes with optional pagination
        public async Task<List<Recipe>> GetRecipesAsync(int pageNumber = 1, int pageSize = 0)
        {
            IOrderedQueryable<Recipe> query = _context.Recipes
                .Include(r => r.Ingredients)
                .Include(r => r.Instructions)
                .OrderBy(r => r.Title);

            // If pageSize is specified, apply pagination; otherwise, fetch all recipes
            if (pageSize > 0)
            {
                query = (IOrderedQueryable<Recipe>)query
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize);
            }

            return await query.ToListAsync();
        }


        // Method to get recipes by a specific user
        public async Task<List<Recipe>> GetRecipesByUserAsync(string userId)
        {
            return await _context.Recipes
                .Where(r => r.OwnerId == userId)
                .Include(r => r.Ingredients)
                .Include(r => r.Instructions)
                .OrderBy(r => r.Title)
                .ToListAsync();
        }

        public async Task<Recipe> GetRecipeByIdAsync(int recipeId)
        {
            return await _context.Recipes
                .Include(r => r.Ingredients)
                .Include(r => r.Instructions)
                .FirstOrDefaultAsync(r => r.Id == recipeId);
        }
    }
}
