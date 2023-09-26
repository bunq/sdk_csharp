using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Object
{
    /// <summary>
    /// </summary>
    public class CardBatchReplaceEntry : BunqModel
    {
        /// <summary>
        /// The ID of the card that needs to be replaced.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }
        /// <summary>
        /// The user's name as it will be on the card. Check 'card-name' for the available card names for a user.
        /// </summary>
        [JsonProperty(PropertyName = "name_on_card")]
        public string NameOnCard { get; set; }
        /// <summary>
        /// Array of Types, PINs, account IDs assigned to the card.
        /// </summary>
        [JsonProperty(PropertyName = "pin_code_assignment")]
        public List<CardPinAssignment> PinCodeAssignment { get; set; }
        /// <summary>
        /// The second line on the card.
        /// </summary>
        [JsonProperty(PropertyName = "second_line")]
        public string SecondLine { get; set; }
    
        public CardBatchReplaceEntry(int? id)
        {
            Id = id;
        }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static CardBatchReplaceEntry CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<CardBatchReplaceEntry>(json);
        }
    }
}
