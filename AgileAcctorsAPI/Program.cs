using Refit;
using ApiAggregator;
using ApiAggregatorConfiguration;
using ApiAggregatorControllers.Refit.OpenWeather;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();

builder.Services.AddControllers();


// Bind configuration
var openWeatherConfig = builder.Configuration.GetSection("OpenWeather").Get<OpenWeatherConfig>();
builder.Services.AddSingleton(openWeatherConfig);

// Register the Refit client
builder.Services.AddRefitClient<IOpenWeatherApi>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = openWeatherConfig.BaseAddress;
    });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
