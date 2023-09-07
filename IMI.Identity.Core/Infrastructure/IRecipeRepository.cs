using IMI.Identity.Core.Entities;

namespace IMI.Identity.Core.Infrastructure;

public interface IRecipeRepository
{
	IQueryable<Recipe> GetAll();

	Task<IEnumerable<Recipe>> ListAllAsync();

	Task<Recipe> GetByIdAsync(Guid id);

	Task<Recipe> UpdateAsync(Recipe entity);

	Task<Recipe> AddAsync(Recipe entity);

	Task<Recipe> DeleteAsync(Recipe entity);

	Task<IEnumerable<Recipe>> GetByUserIdAsync(Guid id);

	Task<IEnumerable<Recipe>> SearchAsync(string search);
}
