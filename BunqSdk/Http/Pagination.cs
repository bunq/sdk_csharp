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
            "Could not generate previous page URL params: previous page not found.";
        private const string ERROR_NO_NEXT_PAGE = "Could not generate next page URL params: next page not found.";

        /// <summary>
        /// URL param constants.
        /// </summary>
        public const string PARAM_OLDER_ID = "older_id";
        public const string PARAM_NEWER_ID = "newer_id";
        public const string PARAM_FUTURE_ID = "future_id";
        public const string PARAM_COUNT = "count";

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
                AssertHasNextPage();

                var urlParams = new Dictionary<string, string>();
                urlParams[PARAM_NEWER_ID] = NextId.ToString();
                AddCountToParamsIfNeeded(urlParams);

                return urlParams;
            }
        }

        private void AssertHasNextPage()
        {
            if (NextId == null)
            {
                throw new BunqException(ERROR_NO_NEXT_PAGE);
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
            get { return HasNextPageAssured() ? NewerId : FutureId; }
        }

        public bool HasNextPageAssured()
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
                AssertHasPreviousPage();

                var urlParams = new Dictionary<string, string>();
                urlParams[PARAM_OLDER_ID] = OlderId.ToString();
                AddCountToParamsIfNeeded(urlParams);

                return urlParams;
            }
        }

        private void AssertHasPreviousPage()
        {
            if (!HasPreviousPage())
            {
                throw new BunqException(ERROR_NO_PREVIOUS_PAGE);
            }
        }

        public bool HasPreviousPage()
        {
            return OlderId != null;
        }
    }
}