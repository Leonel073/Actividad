using Actividad;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Actividad.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//builder.Services.AddScoped<EmpleadoService>();
//builder.Services.AddScoped<JefeRepresentanteService>();
//builder.Services.AddScoped<SucursalService>();
//builder.Services.AddScoped<ClienteService>();

builder.Services.AddSingleton<JefeRepresentanteService>();  // Si JefeRepresentanteService existe, regístralo primero
builder.Services.AddSingleton<SucursalService>();  // Registra SucursalService primero
builder.Services.AddSingleton<EmpleadoService>(sp =>
    new EmpleadoService(new Lazy<SucursalService>(() => sp.GetRequiredService<SucursalService>()))
);  // Usa factory para Lazy en EmpleadoService
builder.Services.AddSingleton<ClienteService>();

await builder.Build().RunAsync();
