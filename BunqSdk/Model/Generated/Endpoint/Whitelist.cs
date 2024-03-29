using Bunq.Sdk.Model.Core;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Bunq.Sdk.Model.Generated.Endpoint
{
    /// <summary>
    /// Whitelist a Request so that when one comes in, it is automatically accepted.
    /// </summary>
    public class Whitelist : BunqModel
    {
    
        /// <summary>
        /// </summary>
        public override bool IsAllFieldNull()
        {
            return true;
        }
    
        /// <summary>
        /// </summary>
        public static Whitelist CreateFromJsonString(string json)
        {
            return BunqModel.CreateFromJsonString<Whitelist>(json);
        }
    }
}
