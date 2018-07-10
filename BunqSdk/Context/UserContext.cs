using System;
using Bunq.Sdk.Exception;
using Bunq.Sdk.Model.Core;
using Bunq.Sdk.Model.Generated.Endpoint;

namespace Bunq.Sdk.Context
{
    public class UserContext
    {
        /// <summary>
        /// Error constatns.
        /// </summary>
        private const string ErrorUnexpectedUser = "\'\"{0}\" is unexpected user instance.\'";

        private const string ErrorNoActiveMonetaryAccountFound = "No active monetary account found.";
        private const string ErrorPirmaryMonetaryAccountHasNotBeenLoaded = "Pirmary monetary account has not been loaded.";
        private const string MonetaryAccountStatusActive = "ACTIVE";
        private MonetaryAccountBank primaryMonetaryAccountBank;

        public UserPerson UserPerson { get; private set; }
        public UserCompany UserCompany { get; private set; }

        public MonetaryAccountBank PrimaryMonetaryAccountBank
        {
            get => primaryMonetaryAccountBank ?? throw new BunqException(ErrorPirmaryMonetaryAccountHasNotBeenLoaded);
            private set => primaryMonetaryAccountBank = value ?? throw new ArgumentNullException(nameof(value));
        }

        public int UserId { get; }

        public UserContext(int userId)
        {
            UserId = userId;

            this.SetUser(GetUserObject());
        }

        private BunqModel GetUserObject()
        {
            return User.List().Value[0].GetReferencedObject();
        }

        private void SetUser(BunqModel user)
        {
            if (user.GetType() == typeof(UserPerson))
            {
                this.UserPerson = (UserPerson) user;
            }
            else if (user.GetType() == typeof(UserCompany))
            {
                this.UserCompany = (UserCompany) user;
            }
            else
            {
                throw new BunqException(string.Format(ErrorUnexpectedUser, user.GetType()));
            }
        }

        public void InitPrimaryMonetaryAccount()
        {
            var allMonetaryAccount = MonetaryAccountBank.List().Value;

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
            return UserCompany == null && UserPerson != null;
        }

        public bool IsOnlyUserCompanySet()
        {
            return UserPerson == null && UserCompany != null;
        }
        
        public void RefreshUserContext()
        {
            SetUser(GetUserObject());
            InitPrimaryMonetaryAccount();
        }
    }
}
