using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mayordomo.Infrastructure.Data.Tables
{
    [Table(nameof(Music), Schema = "dbo")]
    public class Music : DefaultColumns
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public double MaxLenght { get; set; }

        public string Path { get; set; }
    }
}
