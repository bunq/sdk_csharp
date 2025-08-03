using System;
using System.Linq;
using Bunq.Sdk.Exception;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;

namespace Bunq.Sdk.Context
{
    public class UserContext
    {
        /// <summary>
        /// Error constants.
        /// </summary>
        private const string ErrorUnexpectedUser = "\'\"{0}\" is unexpected user instance.\'";
        private const string ErrorNoActiveMonetaryAccountFound = "No active monetary account found.";
        private const string ErrorPirmaryMonetaryAccountHasNotBeenLoaded =
            "Pirmary monetary account has not been loaded.";
        private const string MonetaryAccountStatusActive = "ACTIVE";
        private MonetaryAccountBankApiObject primaryMonetaryAccountBank;

        public UserPersonApiObject UserPerson { get; private set; }
        public UserCompanyApiObject UserCompany { get; private set; }
        public UserApiKeyApiObject UserApiKey { get; private set; }
        public UserPaymentServiceProviderApiObject UserPaymentServiceProvider { get; private set; }

        public MonetaryAccountBankApiObject PrimaryMonetaryAccountBank
        {
            get => primaryMonetaryAccountBank ?? throw new BunqException(ErrorPirmaryMonetaryAccountHasNotBeenLoaded);
            private set => primaryMonetaryAccountBank = value ?? throw new ArgumentNullException(nameof(value));
        }

        public long UserId { get; }

        public UserContext(long userId, BunqModel user)
        {
            UserId = userId;
            SetUser(user);
        }

        private static BunqModel GetUserObject()
        {
            return UserApiObject.List().Value.First().GetReferencedObject();
        }

        private void SetUser(BunqModel user)
        {
            if (user.GetType() == typeof(UserPersonApiObject))
            {
                this.UserPerson = (UserPersonApiObject) user;
            }
            else if (user.GetType() == typeof(UserCompanyApiObject))
            {
                this.UserCompany = (UserCompanyApiObject) user;
            }
            else if (user.GetType() == typeof(UserApiKeyApiObject))
            {
                this.UserApiKey = (UserApiKeyApiObject) user;
            }
            else if (user.GetType() == typeof(UserPaymentServiceProviderApiObject))
            {
                this.UserPaymentServiceProvider = (UserPaymentServiceProviderApiObject) user;
            }
            else
            {
                throw new BunqException(string.Format(ErrorUnexpectedUser, user.GetType()));
            }
        }

        public void InitPrimaryMonetaryAccount()
        {
            if (this.UserPaymentServiceProvider != null)
            {
                return;
            }

            var allMonetaryAccount = MonetaryAccountBankApiObject.List().Value;

            foreach (var accountBank in allMonetaryAccount)
            {
                if (!accountBank.Status.Equals(MonetaryAccountStatusActive)) continue;
                this.PrimaryMonetaryAccountBank = accountBank;

                return;
            }

            throw new BunqException(ErrorNoActiveMonetaryAccountFound);
        }

        public bool IsOnlyUserPersonSet()
        {
            return UserCompany == null && UserApiKey == null && UserPerson != null;
        }

        public bool IsOnlyUserCompanySet()
        {
            return UserPerson == null && UserApiKey == null && UserCompany != null;
        }

        public bool IsOnlyUserApiKeySet()
        {
            return UserApiKey == null && UserCompany != null && UserPerson != null;
        }

        public void RefreshUserContext()
        {
            SetUser(GetUserObject());
            InitPrimaryMonetaryAccount();
        }
    }
}