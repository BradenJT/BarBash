using BarBash.Api.Controllers;
using BarBash.Api.Models;
using BarBash.Api.Services;
using BarBash.Api.Services.Interfaces;
using Polly;
using Polly.Extensions.Http;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<HttpClient>();
builder.Services.AddScoped<IEventService, EventService>();

// Base URL configuration
var baseUrls = new BaseUrls()
{
    EventsApi = builder.Configuration["BaseUrls:EventsApi"]!
};

// Registering the service with HTTP client and policy handler
builder.Services.AddHttpClient<IEventService, EventService>(dmClient =>
{
    dmClient.BaseAddress = new Uri(baseUrls.EventsApi);
}).AddPolicyHandler(
    HttpPolicyExtensions
        .HandleTransientHttpError()
        .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(3))
);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
