using Plugin.WowzaClient;

namespace Mayordomo.App.Plugin.Helpers
{
    public class WowzaCloudConfig : IWowzaConfig
    {
        public WowzaCloudConfig()
        {
        }

        public string HostAddress { get; set; }//=> "0467fc.entrypoint.cloud.wowza.com";

        public int PortNumber { get; set; } //=> 1935;

        public string ApplicationName { get; set; }// => "app-1264";

        public string StreamName { get; set; } //=> "0e68bed6";

        public string Username { get; set; } //=> "client39318";

        public string Password { get; set; } //=> "password";
    }
}
