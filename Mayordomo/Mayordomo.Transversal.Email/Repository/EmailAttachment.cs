namespace Mayordomo.Transversal.Email.Repository
{
    public class EmailAttachment
    {
        public string FileName { get; set; } = string.Empty;
        public byte[] FileContent { get; set; } = Array.Empty<byte>();
    }
}
