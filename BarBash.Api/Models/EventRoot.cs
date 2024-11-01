namespace BarBash.Api.Models
{
    public class EventRoot
    {
        public List<string> AdjacentStates { get; set; } = new List<string>();
        public string CurrentState { get; set; } = string.Empty;
        public List<Event> Events { get; set; } = new List<Event>();
    }
}
