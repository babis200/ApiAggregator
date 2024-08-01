using Refit;
using ApiAggregator;
using ApiAggregatorConfiguration;
using ApiAggregatorClients.Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();

builder.Services.AddControllers();


// Bind configuration
//TODO - put this in seperate class 'AddConfiguration' 
var openWeatherConfig = builder.Configuration.GetSection("OpenWeather").Get<OpenWeatherConfig>();
builder.Services.AddSingleton(openWeatherConfig);

var newsApiConfig = builder.Configuration.GetSection("NewsApi").Get<NewsApiConfig>();
builder.Services.AddSingleton(newsApiConfig);

var spotifyConfig = builder.Configuration.GetSection("Spotify").Get<SpotifyConfig>();
builder.Services.AddSingleton(spotifyConfig);

// Register the Refit client 
//TODO - put this in seperate class 'AddRefit' 
builder.Services.AddRefitClient<IOpenWeatherApi>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = openWeatherConfig.BaseAddress;
    });

builder.Services.AddRefitClient<INewsApi>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = newsApiConfig.BaseAddress;
        c.DefaultRequestHeaders.UserAgent.ParseAdd("ApiAggregator/1.0 (Windows NT 10.0; Win64; x64)");
        c.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("X-Api-Key", newsApiConfig.ApiKey);

    });

builder.Services.AddRefitClient<ISpotifyLoginApi>()
    .ConfigureHttpClient((Action<HttpClient>)(c =>
    {
        c.BaseAddress = spotifyConfig.LoginAddress;
    }));

builder.Services.AddTransient<SpotifyAuthDelegatingHandler>();
builder.Services.AddRefitClient<ISpotifyApi>()
    .AddHttpMessageHandler<SpotifyAuthDelegatingHandler>()
    .ConfigureHttpClient((Action<HttpClient>)(c =>
    {
        c.BaseAddress = spotifyConfig.BaseAddress;
    }));


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
