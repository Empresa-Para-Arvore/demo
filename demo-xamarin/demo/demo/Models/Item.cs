using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace demo.Models {
    public class Item {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "tags")]
        public IList<String> Tags { get; set; } = new List<String>();
    }
}