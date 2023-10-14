using Smartwyre.DeveloperTest.Interface;

namespace Smartwyre.DeveloperTest.Types
{
    internal class FixedCashAmountProcessor : IIncentiveType
    {
        public CalculateRebateResult ProcessRebate(Rebate rebate, Product product, decimal volume)
        {
            var result = new CalculateRebateResult(); 

            if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount))
            {
                result.Success = false;
            }
            else if (rebate.Amount == 0)
            {
                result.Success = false;
            }
            else
            {
                result.RebateAmount = rebate.Amount;
                result.Success = true;
            }

            return result;
        }
    }
}
