using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using FinanceApp.Data;
using System.Reflection;
using FinanceApp.Data;
using Radzen;
using FinanceApp.Services;
using Blazored.SessionStorage;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Register and validate the configuration for API settings
builder.Services.Configure<ApiSettings>(configuration.GetSection("ApiSettings"));
builder.Services.PostConfigure<ApiSettings>(settings =>
{
    if (string.IsNullOrWhiteSpace(settings.Endpoint))
    {
        throw new Exception("The API endpoint must be configured.");
    }
});


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSignalR();
builder.Services.AddCors();

// HTTP Client service
builder.Services.AddHttpClient();

// HttpContextAccessor
builder.Services.AddHttpContextAccessor();

//
builder.Services.AddLogging(builder => builder.AddConsole());
builder.Services.AddSingleton<ISaveService, SaveService>();
builder.Services.AddScoped<ISaveService, SaveService>();

// Singleton services
builder.Services.AddScoped<NotificationService>();
builder.Services.AddSingleton<WeatherForecastService>();

// Register API provider service
builder.Services.AddHttpClient<IApiProvider, ApiProvider>();

//SessionStorage
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddScoped<LoginService>();

// and their namespace ends with "Services"
var assembly = Assembly.Load("FinanceApp");
var serviceTypes = assembly.GetTypes()
    .Where(t => t.IsClass && !t.IsAbstract && t.IsPublic && t.Name.EndsWith("Service") && t.Namespace.EndsWith(".Services"));
foreach (var serviceType in serviceTypes)
{
    builder.Services.AddSingleton(serviceType);
}


var app = builder.Build();
ConfigureApplication(app);

// Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {

//     app.UseExceptionHandler("/Error");
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// }

// app.UseHttpsRedirection();

// app.UseStaticFiles();

// app.UseRouting();

// app.MapBlazorHub();
// app.MapFallbackToPage("/_Host");

app.Run();
// Method to handle all the application configurations
static void ConfigureApplication(WebApplication app)
{
    // Use HSTS and redirect to HTTPS in non-development environments
    if (!app.Environment.IsDevelopment())
    {
        // Customize the error handling middleware to log the errors
        app.UseExceptionHandler(errorApp =>
        {
            errorApp.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerPathFeature>();
                var logger = context.RequestServices.GetRequiredService<ILogger<Program>>();
                logger.LogError(exceptionHandlerPathFeature.Error, "An unhandled exception has occurred while executing the request.");

                // Redirect to the error page
                context.Response.Redirect("/Error");
            });
        });

        app.UseHsts();
        app.UseHttpsRedirection();
        app.UseCors(builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
    }

    // Static file handling
    app.UseStaticFiles();
    app.UseCors("AllowAll");

    // Routing and endpoint mapping
    app.UseRouting();
    app.MapBlazorHub();
    app.MapFallbackToPage("/_Host");

    // Add additional middleware here...
}