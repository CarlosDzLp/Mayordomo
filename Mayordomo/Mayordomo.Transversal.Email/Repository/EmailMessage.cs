namespace Mayordomo.Transversal.Email.Repository
{
    public class EmailMessage
    {
        public List<string> To { get; set; } = new();
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public bool IsHtml { get; set; } = true;
        public List<EmailAttachment>? Attachments { get; set; }
    }
}
