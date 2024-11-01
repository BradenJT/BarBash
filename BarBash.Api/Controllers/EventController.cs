using BarBash.Api.Models;
using BarBash.Api.Services;
using BarBash.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BarBash.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController(IEventService eventServices) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Event>>> Get()
          => await eventServices.GetEventsAsync();
    }
}
