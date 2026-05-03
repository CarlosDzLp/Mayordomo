using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mayordomo.Infrastructure.Data.Tables
{
    [Table(nameof(Code), Schema = "dbo")]
    public class Code : DefaultColumns
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey(nameof(User)), Required]
        public Guid UserId { get; set; }

        public User User { get; set; }

        public string Value { get; set; }

        public DateTime Expired { get; set; }
    }
}
