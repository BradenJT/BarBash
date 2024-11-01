using BarBash.Api.Models;
using BarBash.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace BarBash.Api.Services
{
    public class EventService(HttpClient httpClient) : IEventService
    {
        public async Task<List<Event>> GetEventsAsync()
        {
            try
            {
                HttpResponseMessage responseMessage = await httpClient.GetAsync("events");

                responseMessage.EnsureSuccessStatusCode();
                string responseBody = await responseMessage.Content.ReadAsStringAsync();

                var apiResponse = JsonSerializer.Deserialize<EventRoot>(responseBody, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                if (apiResponse is null)
                    throw new NotImplementedException("No events found. Please try again");

                return apiResponse.Events;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException($"Error fetching events: {ex.Message}");
            }
        }
    }
}
