using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Services;

namespace Smartwyre.DeveloperTest.Factories
{
    public class SmartwyreFactory
    {
        public static IRebateService CreateRebateService() => new RebateService(new RebateDataStore(), new ProductDataStore());
    }
}
