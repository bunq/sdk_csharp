namespace Bunq.Sdk.Model.Core
{
    public interface IAnchorObjectInterface
    {
        bool AreAllFieldNull();

        BunqModel GetReferencedObject();
    }
}