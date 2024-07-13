using Autofac;
using Autofac.Extensions.DependencyInjection;
using Blazored.LocalStorage;
using Blazorise;
using Blazorise.Bootstrap5;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Toolbelt.Blazor.Extensions.DependencyInjection;
using WebAssemblyProject;
using WebAssemblyProject.Authentication;
using Microsoft.Extensions.Configuration;
using Autofac.Core;
using DataAccess.Concrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

///Autofac
var containerBuilder = new ContainerBuilder();

containerBuilder.Populate(builder.Services);

var container = containerBuilder.Build();

var serviceProvider = new AutofacServiceProvider(container);

builder.Services.AddSingleton<IServiceProvider>(serviceProvider);

// Add configuration for appsettings.json
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();


builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
    })
    .AddBootstrap5Providers()
    .AddFontAwesomeIcons();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();


builder.Services.AddAuthorizationCore();
builder.Services.AddApiAuthorization();


builder.Services.AddSingleton<IConfiguration>(config);
builder.Services.AddAntDesign();
builder.Services.AddHttpClientInterceptor();

await builder.Build().RunAsync();
