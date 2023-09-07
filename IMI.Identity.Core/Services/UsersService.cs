using IMI.Identity.Core.Entities;
using IMI.Identity.Core.Infrastructure;
using IMI.Identity.Core.Services.Interfaces;
using IMI.Identity.Core.Services.Models;
using System.ComponentModel.DataAnnotations;

namespace IMI.Identity.Core.Services;

public class UsersService : IUsersService
{
	private readonly IUserRepository _userRepository;

	public UsersService(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<ViewUsersResult> GetAllUsers()
	{
		var result = new ViewUsersResult();
		result.ValidationResults = new List<ValidationResult>();

		result.Users = await _userRepository.ListAllAsync();
		result.IsSuccess = true;

		return result;
	}

	public async Task<ViewUsersResult> GetUserById(Guid id)
	{
		var result = new ViewUsersResult();
		var validationResults = new List<ValidationResult>();

		var user = await _userRepository.GetByIdAsync(id);

		if (user == null)
		{
			validationResults.Add(new ValidationResult($"User with id {id} is not found."));
			result.IsSuccess = false;
		}
		else
		{
			var users = new List<User>();
			users.Add(user);
			result.Users = users;
			result.IsSuccess = true;
		}

		result.ValidationResults = validationResults;

		return result;
	}

	public async Task<ViewUsersResult> SearchUserByName(string searchInput)
	{
		var result = new ViewUsersResult();
		var validationResults = new List<ValidationResult>();

		if (string.IsNullOrWhiteSpace(searchInput))
		{
			validationResults.Add(new ValidationResult($"No searchtext provided!"));
			result.IsSuccess = false;
		}
		else if (searchInput.Length <= 2)
		{
			validationResults.Add(new ValidationResult($"At least 3 characters are required to search for users."));
			result.IsSuccess = false;
		}
		else
		{
			var users = await _userRepository.SearchAsync(searchInput);
			result.Users = users;
			result.IsSuccess = true;
		}

		result.ValidationResults = validationResults;
		return result;
	}
}