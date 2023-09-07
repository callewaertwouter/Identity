using IMI.Identity.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace IMI.Identity.Core.Services.Models;

public class ViewUsersResult
{
    protected IEnumerable<ValidationResult> _validationResults;

    public IEnumerable<ValidationResult> ValidationResults { get; set; } = new ValidationResult[0];

    public bool IsSuccess { get; set; }

    public IEnumerable<User> Users { get; set; }
}
