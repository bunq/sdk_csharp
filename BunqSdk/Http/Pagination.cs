using System.Collections.Generic;
using Bunq.Sdk.Exception;

namespace Bunq.Sdk.Http
{
    public class Pagination
    {
        /// <summary>
        /// Error constants.
        /// </summary>
        private const string ERROR_NO_PREVIOUS_PAGE =
            "Could not generate previous page URL params: there is no previous page.";

        /// <summary>
        /// URL param constants.
        /// </summary>
        public const string PARAM_OLDER_ID = "older_id";
        public const string PARAM_NEWER_ID = "newer_id";
        public const string PARAM_FUTURE_ID = "future_id";
        public const string PARAM_COUNT = "count";

        /// <summary>
        /// Field constants.
        /// </summary>
        private const string FIELD_OLDER_URL = "older_url";
        private const string FIELD_NEWER_URL = "newer_url";
        private const string FIELD_FUTURE_URL = "future_url";

        public int? OlderId { get; set; }
        public int? NewerId { get; set; }
        public int? FutureId { get; set; }
        public int? Count { get; set; }

        /// <summary>
        /// Get the URL params required to request the next page of the listing.
        /// </summary>
        public IDictionary<string, string> UrlParamsNextPage
        {
            get
            {
                var urlParams = new Dictionary<string, string>();
                urlParams[PARAM_NEWER_ID] = NextId.ToString();
                AddCountToParamsIfNeeded(urlParams);

                return urlParams;
            }
        }

        private void AddCountToParamsIfNeeded(IDictionary<string, string> urlParams)
        {
            if (Count != null)
            {
                urlParams[PARAM_COUNT] = Count.ToString();
            }
        }

        private int? NextId
        {
            get { return HasNextItemAssured() ? NewerId : FutureId; }
        }

        public bool HasNextItemAssured()
        {
            return NewerId != null;
        }

        /// <summary>
        /// Get the URL params required to request the latest page with count of this pagination.
        /// </summary>
        public IDictionary<string, string> UrlParamsCountOnly
        {
            get
            {
                var urlParams = new Dictionary<string, string>();
                AddCountToParamsIfNeeded(urlParams);

                return urlParams;
            }
        }

        /// <summary>
        /// Get the URL params required to request the previous page of the listing.
        /// </summary>
        public IDictionary<string, string> UrlParamsPreviousPage
        {
            get
            {
                if (!HasPreviousItem())
                {
                    throw new BunqException(ERROR_NO_PREVIOUS_PAGE);
                }

                var urlParams = new Dictionary<string, string>();
                urlParams[PARAM_OLDER_ID] = OlderId.ToString();
                AddCountToParamsIfNeeded(urlParams);

                return urlParams;
            }
        }

        public bool HasPreviousItem()
        {
            return OlderId != null;
        }
    }
}
