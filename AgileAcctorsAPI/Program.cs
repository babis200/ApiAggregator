using Refit;
using ApiAggregator;
using ApiAggregatorConfiguration;
using ApiAggregatorClients.Refit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplication();

builder.Services.AddControllers();

ConfigureOpenWeather(builder);

ConfigureNewsApi(builder);

ConfigureSpotify(builder);

ConfigureTrivia(builder);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMvc();

app.MapControllers();

app.Run();

static void ConfigureOpenWeather(WebApplicationBuilder builder)
{
    var openWeatherConfig = builder.Configuration.GetSection("OpenWeather").Get<OpenWeatherConfig>();
    builder.Services.AddSingleton(openWeatherConfig);
    builder.Services.AddRefitClient<IOpenWeatherApi>()
        .ConfigureHttpClient(c =>
        {
            c.BaseAddress = openWeatherConfig.BaseAddress;
        });
}

static void ConfigureNewsApi(WebApplicationBuilder builder)
{
    var newsApiConfig = builder.Configuration.GetSection("NewsApi").Get<NewsApiConfig>();
    builder.Services.AddSingleton(newsApiConfig);

    builder.Services.AddRefitClient<INewsApi>()
        .ConfigureHttpClient(c =>
        {
            c.BaseAddress = newsApiConfig.BaseAddress;
            c.DefaultRequestHeaders.UserAgent.ParseAdd("ApiAggregator/1.0 (Windows NT 10.0; Win64; x64)");
            c.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("X-Api-Key", newsApiConfig.ApiKey);
        });
}

static void ConfigureSpotify(WebApplicationBuilder builder)
{
    var spotifyConfig = builder.Configuration.GetSection("Spotify").Get<SpotifyConfig>();
    builder.Services.AddSingleton(spotifyConfig);

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
}

static void ConfigureTrivia(WebApplicationBuilder builder)
{
    var openWeatherConfig = builder.Configuration.GetSection("Trivia").Get<TriviaConfig>();
    builder.Services.AddSingleton(openWeatherConfig);
    builder.Services.AddRefitClient<ITriviaApi>()
        .ConfigureHttpClient(c =>
        {
            c.BaseAddress = openWeatherConfig.BaseAddress;
        });
}
