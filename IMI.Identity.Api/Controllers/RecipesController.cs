using IMI.Identity.Core.DTOs.Recipe;
using IMI.Identity.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace IMI.Identity.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
	protected readonly IRecipeRepository _recipeRepository;

    public RecipesController(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		var recipes = await _recipeRepository.ListAllAsync();
		var recipesDto = recipes.Select(r => new RecipeResponseDto
		{
			Title = r.Title
		});

		return Ok(recipesDto);
	}
}
