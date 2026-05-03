namespace Mayordomo.Infrastructure.Data
{
    public class DefaultColumns
    {
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
