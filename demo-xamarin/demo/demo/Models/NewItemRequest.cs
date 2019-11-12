using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace demo.Models {
    public class ItemRequest : Item {
        [JsonProperty(PropertyName = "score")] 
        public int Score { get; } = 5;

        public ItemRequest(Item i) {
            this.Title = i.Title;
            this.Description = i.Description;
            this.Tags = i.Tags;
        }
    }
    
    public class NewItemRequest {
        [JsonProperty(PropertyName = "userId")] 
        public string UserId { get; set; }
        [JsonProperty(PropertyName = "item")]
        public ItemRequest item { get; set; }
    }
}