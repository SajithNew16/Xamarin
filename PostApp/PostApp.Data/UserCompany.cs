using Newtonsoft.Json;

namespace PostApp.Data
{
    public class UserCompany
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "catchPhrase")]
        public string CatchPhrase { get; set; }

        [JsonProperty(PropertyName = "bs")]
        public string Bs { get; set; }
    }
}