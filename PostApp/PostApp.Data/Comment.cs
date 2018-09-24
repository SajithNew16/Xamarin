using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostApp.Data
{
    public class Comment
    {
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        [JsonProperty(PropertyName = "postId")]
        public int? PostId { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }

    }
}
