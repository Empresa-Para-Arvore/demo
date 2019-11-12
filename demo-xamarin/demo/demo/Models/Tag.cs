using Newtonsoft.Json;

namespace demo.Models {
    public class Tag {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}