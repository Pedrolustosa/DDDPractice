using DDDPractice.CrossCutting.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureDependenciesJWT(configuration);
builder.Services.ConfigureDependenciesSwagger(configuration);
builder.Services.ConfigureDependenciesService(configuration);
builder.Services.ConfigureDependenciesMappings(configuration);
builder.Services.ConfigureDependenciesRepository(configuration);

// Configure the HTTP request pipeline.
var app = builder.Build();
if (true)
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DDDPractice.API v1"));
}
app.UseAuthorization();
app.MapControllers();
app.Run();
