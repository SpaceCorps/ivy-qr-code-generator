using IvyQrCodeGenerator.Apps;
using IvyQrCodeGenerator.Services;

CultureInfo.DefaultThreadCurrentCulture = CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");
var server = new Server();
#if DEBUG
server.UseHotReload();
#endif
server.AddAppsFromAssembly();
server.AddConnectionsFromAssembly();

// Register services
server.Services.AddScoped<IQrCodeService, QrCodeService>();
var chromeSettings = new ChromeSettings().DefaultApp<HelloApp>().UseTabs(preventDuplicates: true);
server.UseChrome(chromeSettings);
await server.RunAsync();
