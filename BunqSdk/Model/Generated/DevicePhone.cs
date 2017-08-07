using Newtonsoft.Json;

namespace Bunq.Sdk.Model.Generated
{
    /// <summary>
    /// Used to register a device. This is the only unsigned/verified request.
    /// </summary>
    public class DevicePhone : BunqModel
    {
        /// <summary>
        /// Field constants.
        /// </summary>
        public const string FIELD_DESCRIPTION = "description";
        public const string FIELD_PHONE_NUMBER = "phone_number";

        /// <summary>
        /// Object type.
        /// </summary>
        private const string OBJECT_TYPE = "DevicePhone";

        /// <summary>
        /// The id of the DevicePhone as created on the server.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public int? Id { get; private set; }

        /// <summary>
        /// The timestamp of the DevicePhone's creation.
        /// </summary>
        [JsonProperty(PropertyName = "created")]
        public string Created { get; private set; }

        /// <summary>
        /// The timestamp of the DevicePhone's last update.
        /// </summary>
        [JsonProperty(PropertyName = "updated")]
        public string Updated { get; private set; }

        /// <summary>
        /// The description of the DevicePhone.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; private set; }

        /// <summary>
        /// The phone number used to register the DevicePhone.
        /// </summary>
        [JsonProperty(PropertyName = "phone_number")]
        public string PhoneNumber { get; private set; }

        /// <summary>
        /// The operating system running on this phone.
        /// </summary>
        [JsonProperty(PropertyName = "os")]
        public string Os { get; private set; }

        /// <summary>
        /// The status of the DevicePhone.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status { get; private set; }
    }
}
