namespace Bunq.Sdk.Model.Core
{
    public interface IAnchorObjectInterface
    {
        bool IsAllFieldNull();

        BunqModel GetReferencedObject();
    }
}