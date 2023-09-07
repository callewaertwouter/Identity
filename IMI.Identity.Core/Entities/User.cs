using Microsoft.AspNetCore.Identity;

namespace IMI.Identity.Core.Entities
{
	public class User : IdentityUser
	{
        public DateTime Birthday { get; set; } = new DateTime(1990, 1, 1);

        public bool HasApprovedTermsAndConditions { get; set; }
    }
}
