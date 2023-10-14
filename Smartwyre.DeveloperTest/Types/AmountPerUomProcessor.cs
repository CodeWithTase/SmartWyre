using Smartwyre.DeveloperTest.Interface;

namespace Smartwyre.DeveloperTest.Types
{
    internal class AmountPerUomProcessor : IIncentiveType
    {
        public CalculateRebateResult ProcessRebate(Rebate rebate, Product product, decimal volume)
        {
            var result = new CalculateRebateResult();

            if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom))
            {
                result.Success = false;
            }
            else if (rebate.Amount == 0 || volume == 0)
            {
                result.Success = false;
            }
            else
            {
                result.RebateAmount += rebate.Amount * volume;
                result.Success = true;
            }

            return result;
        }
    }
}
