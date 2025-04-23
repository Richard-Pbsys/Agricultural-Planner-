using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VHS.Data.Models.Auth
{
    public class User
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [MaxLength(255)]
        public string Auth0Id { get; set; } = string.Empty;

        public DateTime AddedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public DateTime? DeletedDateTime { get; set; }

        [InverseProperty("User")]
        public virtual UserSetting? UserSetting { get; set; }

        public User()
        {
            AddedDateTime = DateTime.UtcNow;
            ModifiedDateTime = DateTime.UtcNow;
        }
    }
}
