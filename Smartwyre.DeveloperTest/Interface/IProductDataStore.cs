using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Interface
{
    public interface IProductDataStore
    {
        Product GetProduct(string productIdentifier);
    }
}
