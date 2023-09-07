using IMI.Identity.Core.Entities;
using IMI.Identity.Core.Infrastructure;
using IMI.Identity.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IMI.Identity.Infrastructure.Repositories;

public class RecipeRepository : IRecipeRepository
{
	protected readonly ApplicationDbContext _context;

	public RecipeRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public IQueryable<Recipe> GetAll()
	{
		return _context.Recipes;
	}

	public async Task<IEnumerable<Recipe>> ListAllAsync()
	{
		var recipes = await GetAll().ToListAsync();

		return recipes;
	}

	public async Task<Recipe> GetByIdAsync(Guid id)
	{
		var recipe = await GetAll().SingleOrDefaultAsync(r => r.Id.Equals(id));

		return recipe;
	}

	public Task<IEnumerable<Recipe>> GetByUserIdAsync(Guid id)
	{
		throw new NotImplementedException();
	}

	public Task<IEnumerable<Recipe>> SearchAsync(string search)
	{
		throw new NotImplementedException();
	}

	public Task<Recipe> UpdateAsync(Recipe entity)
	{
		throw new NotImplementedException();
	}

	public Task<Recipe> AddAsync(Recipe entity)
	{
		throw new NotImplementedException();
	}

	public Task<Recipe> DeleteAsync(Recipe entity)
	{
		throw new NotImplementedException();
	}
}
