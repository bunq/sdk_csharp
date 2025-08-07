using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Object;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// view for creating the feature announcement.
    /// </summary>
    public class FeatureAnnouncementApiObject : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_AVATAR_UUID = "avatar_uuid";
        public const string FIELD_TITLE = "title";
        public const string FIELD_SUB_TITLE = "sub_title";
        public const string FIELD_STATUS = "status";
        public const string FIELD_FEATURE_ACCESS_ID = "feature_access_id";
        public const string FIELD_CONTENT_TYPE = "content_type";
    
    
        /// <summary>
        /// The avatar uuid.
        /// </summary>
        [JsonProperty(PropertyName = "avatar_uuid")]
        public string AvatarUuid { get; set; }
        /// <summary>
        /// The event title of the feature announcement.
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public List<string> Title { get; set; }
        /// <summary>
        /// The event sub title of the feature announcement.
        /// </summary>
        [JsonProperty(PropertyName = "sub_title")]
        public List<string> SubTitle { get; set; }
        /// <summary>
        /// The status of the feature announcement.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; set; }
        /// <summary>
        /// The feature access id that controls the feature announcement.
        /// </summary>
        [JsonProperty(PropertyName = "feature_access_id")]
        public string FeatureAccessId { get; set; }
        /// <summary>
        /// The content type of the feature announcement.
        /// </summary>
        [JsonProperty(PropertyName = "content_type")]
        public string ContentType { get; set; }
        /// <summary>
        /// The Avatar of the event overview.
        /// </summary>
        [JsonProperty(PropertyName = "avatar")]
        public AvatarObject Avatar { get; set; }
        /// <summary>
        /// The type of the feature announcement.
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        /// <summary>
        /// The event sub title of the feature announcement.
        /// </summary>
        [JsonProperty(PropertyName = "all_feature_announcement_content")]
        public List<string> AllFeatureAnnouncementContent { get; set; }
    
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            if (this.Avatar != null)
            {
                return false;
            }
    
            if (this.Title != null)
            {
                return false;
            }
    
            if (this.SubTitle != null)
            {
                return false;
            }
    
            if (this.Type != null)
            {
                return false;
            }
    
            if (this.Status != null)
            {
                return false;
            }
    
            if (this.AllFeatureAnnouncementContent != null)
            {
                return false;
            }
    
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static FeatureAnnouncementApiObject CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<FeatureAnnouncementApiObject>(json);
        }
    }
}
