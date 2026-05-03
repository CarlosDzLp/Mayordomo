using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mayordomo.Infrastructure.Data.Tables
{
    [Table(nameof(UserMusic), Schema = "dbo")]
    public class UserMusic : DefaultColumns
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey(nameof(User)), Required]
        public Guid UserId { get; set; }

        [ForeignKey(nameof(Music)), Required]
        public Guid MusicId { get; set; }

        public User User { get; set; }

        public Music Music { get; set; }
    }
}
