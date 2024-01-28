using Microsoft.AspNetCore.Mvc;
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

app.UseAuthorization();

app.MapControllers();

app.Run();
