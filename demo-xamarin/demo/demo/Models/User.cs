using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace demo.Models {
    public class User {
        [JsonProperty(PropertyName = "_id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name{ get; set; }
        [JsonProperty(PropertyName = "email")]
        public string Email{ get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
        [JsonProperty(PropertyName = "items")]
        public IList<Item> Items { get; set; } 
    }
}