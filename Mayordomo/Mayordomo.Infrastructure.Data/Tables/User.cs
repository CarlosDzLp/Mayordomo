using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mayordomo.Infrastructure.Data.Tables
{
    [Table(nameof(User), Schema = "dbo")]
    public class User : DefaultColumns
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Roles)), Required]
        public Guid RoleId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public string? PlayerId { get; set; }

        public string? Image { get; set; }

        public Roles Roles { get; set; }
    }
}
