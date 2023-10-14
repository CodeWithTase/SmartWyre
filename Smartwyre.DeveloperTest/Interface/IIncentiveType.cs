using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Interface
{
    internal interface IIncentiveType
    {
        CalculateRebateResult ProcessRebate(Rebate rebate, Product product, decimal volume);
    }
}
