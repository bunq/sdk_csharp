using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Used to view OAuth request detais in events.
    /// </summary>
    public class UserApiKey : BunqModel
    {
        /// <summary>
        /// The id of the user.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; set; }

        /// <summary>
        /// The timestamp of the user object's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; set; }

        /// <summary>
        /// The timestamp of the user object's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; set; }

        /// <summary>
        /// The user who requested access.
        /// </summary>
        [JsonProperty(PropertyName = "requested_by_user")]
        public UserApiKeyAnchoredUser RequestedByUser { get; set; }

        /// <summary>
        /// The user who granted access.
        /// </summary>
        [JsonProperty(PropertyName = "granted_by_user")]
        public UserApiKeyAnchoredUser GrantedByUser { get; set; }

        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Id != null)
            {
                return false;
            }

            if (this.Created != null)
            {
                return false;
            }

            if (this.Updated != null)
            {
                return false;
            }

            if (this.RequestedByUser != null)
            {
                return false;
            }

            if (this.GrantedByUser != null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// </summary>
        public static UserApiKey CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<UserApiKey>(json);
        }
    }
}