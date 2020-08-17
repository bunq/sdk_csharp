using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class TabTextWaitingScreen : BunqModel
    {
        public TabTextWaitingScreen(string language, string description)
        {
            Language = language;
            Description = description;
        }

        /// <summary>
        ///     Language of tab text
        /// </summary>
        [JsonProperty(PropertyName = "language")]
        public string Language { get; set; }

        /// <summary>
        ///     Tab text
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }


        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (Language != null) return false;

            if (Description != null) return false;

            return true;
        }

        /// <summary>
        /// </summary>
        public static TabTextWaitingScreen CreateFromJsonString(string json)
        {
            return CreateFromJsonString<TabTextWaitingScreen>(json);
        }
    }
}