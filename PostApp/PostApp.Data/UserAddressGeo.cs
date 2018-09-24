using Newtonsoft.Json;

namespace PostApp.Data
{
    public class UserAddressGeo
    {
        [JsonProperty(PropertyName = "lat")]
        public double? Lat { get; set; }

        [JsonProperty(PropertyName = "lng")]
        public double? Lng { get; set; }
    }
}