using IMI.Identity.Core.Services.Models;

namespace IMI.Identity.Core.Services.Interfaces;

public interface IUsersService
{
	Task<ViewUsersResult> GetAllUsers();
	Task<ViewUsersResult> GetUserById(Guid id);
	Task<ViewUsersResult> SearchUserByName(string searchInput);
}
