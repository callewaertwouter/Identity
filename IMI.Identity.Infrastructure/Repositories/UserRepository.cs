using IMI.Identity.Core.Entities;
using IMI.Identity.Core.Infrastructure;
using IMI.Identity.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IMI.Identity.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
	protected readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
		_context = context;
    }

    public IQueryable<User> GetAll()
	{
		return _context.Users;
	}

	public async Task<IEnumerable<User>> ListAllAsync()
	{
		var users = await GetAll().ToListAsync();

		return users;
	}

	public async Task<User> GetByIdAsync(Guid id)
	{
		var user = await GetAll().SingleOrDefaultAsync(r => r.Id.Equals(id));

		return user;
	}

	public async Task<User> AddAsync(User entity)
	{
		_context.Set<User>().Add(entity);

		await _context.SaveChangesAsync();

		return entity;
	}

	public async Task<User> UpdateAsync(User entity)
	{
		_context.Set<User>().Update(entity);

		await _context.SaveChangesAsync();

		return entity;
	}

	public async Task<User> DeleteAsync(User entity)
	{
		_context.Set<User>().Remove(entity);

		await _context.SaveChangesAsync();

		return entity;
	}

	public async Task<IEnumerable<User>> SearchAsync(string search)
	{
		var users = await GetAll()
							.Where(u => u.Email.Contains(search.Trim().ToUpper()))
							.ToListAsync();

		return users;
	}
}
