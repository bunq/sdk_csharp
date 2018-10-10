using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

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

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Language != null)
            {
                return false;
            }

            if (this.Description != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static TabTextWaitingScreen CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<TabTextWaitingScreen>(json);
        }
    }
}