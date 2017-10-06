using Bunq.Sdk.Model.Generated.Object;

namespace Bunq.Sdk.Model.Core
{
    /// <summary>
    /// Adapter required to provide compatibility between the two types used to refer to Monetary Accounts: Pointers in
    /// requests and Monetary Account Labels in responses.
    /// </summary>
    public class MonetaryAccountReference
    {
        public Pointer Pointer { get; private set; }
        public LabelMonetaryAccount LabelMonetaryAccount { get; private set; }

        public MonetaryAccountReference(Pointer pointer)
        {
            Pointer = pointer;
        }

        public MonetaryAccountReference(LabelMonetaryAccount labelMonetaryAccount)
        {
            LabelMonetaryAccount = labelMonetaryAccount;
        }
    }
}
