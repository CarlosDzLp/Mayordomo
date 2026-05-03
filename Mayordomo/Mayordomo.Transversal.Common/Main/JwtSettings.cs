namespace Mayordomo.Transversal.Common.Main
{
    public class JwtSettings
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string AccessTokenExpirationMinutes { get; set; }
        public string RefreshTokenExpirationDays { get; set; }
    }
}
