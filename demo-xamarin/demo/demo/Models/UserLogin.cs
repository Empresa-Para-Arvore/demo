using System.Collections.Generic;
using Newtonsoft.Json;

namespace demo.Models {
    public class UserLogin {
        [JsonProperty(PropertyName = "email")] 
        public string Email { get; set; } = "marcos.paulo@zup.com.br";

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; } = "123456";
    }
}