using Mayordomo.Transversal.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mayordomo.Infrastructure.Data.Tables
{
    [Table(nameof(Roles), Schema = "dbo")]
    public class Roles : DefaultColumns
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public RoleName Name { get; set; }

        public string? Description { get; set; }
    }
}
