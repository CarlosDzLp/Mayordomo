using Mayordomo.Configure;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Services.AddServiceConfigure(builder);
app.AddAppConfigure(builder.Services, app);
await app.RunAsync();
