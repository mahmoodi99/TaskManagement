using AutoMapper;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using UI;
using UI.ServiceHttp;
using Microsoft.AspNetCore.Components.Authorization;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IActivityHttpService, ActivityHttpService>();
builder.Services.AddScoped<IStatusHttpService, StatusHttpService>();
builder.Services.AddScoped<IUserHttpService, UserHttpService>();
builder.Services.AddScoped<IUnitHttpService, UnitHttpService>();
builder.Services.AddScoped<IRoleHttpService, RoleHttpService>();
builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<IFilterHttpService, FilterHttpService>();
builder.Services.AddScoped<ILogHttp_ActivityService, LogHttp_ActivityService>();
builder.Services.AddScoped<ILoginUserService, LoginUserService>();
builder.Services.AddAuthorizationCore();
builder.Services.AddOptions();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddScoped<CookieHandler>();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();
builder.Services.AddScoped<IMapper, Mapper>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7064/Api/") });
builder.Services.AddHttpClient("API", options =>
{
    options.BaseAddress = new Uri("https://localhost:7064/Api/");
})
.AddHttpMessageHandler<CookieHandler>();
builder.Services.AddAuthorizationCore();
var host = builder.Build();
await builder.Build().RunAsync();


