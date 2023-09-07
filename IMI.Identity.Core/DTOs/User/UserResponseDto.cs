namespace IMI.Identity.Core.DTOs.User;

public class UserResponseDto
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public bool HasApprovedTermsAndConditions { get; set; }
}
