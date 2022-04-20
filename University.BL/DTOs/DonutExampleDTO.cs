using Newtonsoft.Json;

namespace University.BL.DTOs
{
    public class DonutExampleDTO
    {
        [JsonProperty("value")]
        public float Value { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }
    }
}
