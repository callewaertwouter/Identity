using IMI.Identity.Core.Entities;

namespace IMI.Identity.Core.Infrastructure;

public interface IUserRepository
{
	Task<IEnumerable<User>> SearchAsync(string search);

	IQueryable<User> GetAll();

	Task<IEnumerable<User>> ListAllAsync();

	Task<User> GetByIdAsync(Guid id);

	Task<User> UpdateAsync(User entity);

	Task<User> AddAsync(User entity);

	Task<User> DeleteAsync(User entity);
}
