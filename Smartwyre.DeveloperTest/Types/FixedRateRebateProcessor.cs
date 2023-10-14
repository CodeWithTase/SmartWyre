using Smartwyre.DeveloperTest.Interface;

namespace Smartwyre.DeveloperTest.Types
{
    internal class FixedRateRebateProcessor : IIncentiveType
    {
        public CalculateRebateResult ProcessRebate(Rebate rebate, Product product, decimal volume)
        {
            var result = new CalculateRebateResult();

            if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate))
            {
                result.Success = false;
            }
            else if (rebate.Percentage == 0 || product.Price == 0 || volume == 0)
            {
                result.Success = false;
            }
            else
            {
                result.RebateAmount += product.Price * rebate.Percentage * volume;
                result.Success = true;
            }

            return result;
        }
    }
}
