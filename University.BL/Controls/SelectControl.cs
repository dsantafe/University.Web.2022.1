using Newtonsoft.Json;

namespace University.BL.Controls
{
    public class SelectControl
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }
    }
}
