using System.Text.Json.Serialization;

namespace BarBash.Api.Models
{
    public class Event
    {
        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("created")]
        public string Created { get; set; }

        [JsonPropertyName("evt_name")]
        public string EvtName { get; set; }

        [JsonPropertyName("fed")]
        public string Fed { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }

        [JsonPropertyName("parsed_date")]
        public string ParsedDate { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        // Optional: Define a helper method to parse dates after deserialization
        public DateTime? GetParsedDate()
        {
            return DateTime.TryParse(ParsedDate, out var parsedDate) ? parsedDate : (DateTime?)null;
        }
        public DateTime? GetCreatedDate()
        {
            return DateTime.TryParse(Created, out var createdDate) ? createdDate : (DateTime?)null;
        }
    }

}
