using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    options.JsonSerializerOptions.WriteIndented = true;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
}).ConfigureApiBehaviorOptions(options =>
{
    //suppress automatic model state binding errors
    options.SuppressModelStateInvalidFilter = true;
    options.SuppressMapClientErrors = false;
    options.ClientErrorMapping[StatusCodes.Status404NotFound].Link =
        "https://www.nklou.org/";
    options.ClientErrorMapping[StatusCodes.Status404NotFound].Title =
        "End point is invalid";
});

builder.Services.AddApiVersioning();
builder.Services.AddAutoLotApiVersionConfiguration(new ApiVersion(1, 0));

builder.Services.AddDataServices();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckleteetsss
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAndConfigureSwagger(
    builder.Configuration,
    Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"),
    true);

// cross-origin request config
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowAnyOrigin();
    });
});

// Get user and password to option
builder.Services.Configure<SecuritySettings>(builder.Configuration.GetSection(nameof(SecuritySettings)));

builder.Services.AddAuthentication("BasicAuthentication")
    .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
        options =>
        {
            using var scope = app.Services.CreateScope();
            var versionProvider = scope.ServiceProvider.GetRequiredService<IApiVersionDescriptionProvider>();
            // build a swagger endpoint for each discovered API version
            foreach (var description in versionProvider.ApiVersionDescriptions)
            {
                options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant());
            }
        });
}

app.UseHttpsRedirection();

//Add CORS Policy
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
