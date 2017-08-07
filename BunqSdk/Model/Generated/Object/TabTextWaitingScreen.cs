using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class TabTextWaitingScreen : BunqModel
    {
        /// <summary>
        /// Language of tab text
        /// </summary>
        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }

        /// <summary>
        /// Tab text
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        public TabTextWaitingScreen(string language, string description)
        {
            Language = language;
            Description = description;
        }
    }
}
