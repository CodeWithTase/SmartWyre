using Smartwyre.DeveloperTest.Factories;
using Smartwyre.DeveloperTest.Interface;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    private IRebateDataStore _rebateDataStore;
    private IProductDataStore _productDataStore;

    public RebateService(IRebateDataStore rebateDataStore, IProductDataStore productDataStore)
    {
        _rebateDataStore = rebateDataStore;
        _productDataStore = productDataStore;
    }
    public CalculateRebateResult ProcessRequest(CalculateRebateRequest request)
    {
        var rebate = _rebateDataStore.GetRebate(request.RebateIdentifier);
        var product = _productDataStore.GetProduct(request.ProductIdentifier);

        var result = new CalculateRebateResult();

        if (rebate == null)
        {
            result.Success = false;
            return result;
        }
        if (product == null)
        {
            result.Success = false;
            return result;
        }

        result = Calculate(request, rebate, product);

        StoreCalculationResult(rebate, result);

        return result;
    }

    private void StoreCalculationResult(Rebate rebate, CalculateRebateResult result)
    {
        if (result.Success)
        {
            _rebateDataStore.StoreCalculationResult(rebate, result.RebateAmount);
        }
    }

    private CalculateRebateResult Calculate(
        CalculateRebateRequest request,
        Rebate rebate,
        Product product)
    {
        var incentiveTypeFactory = new IncentiveTypeFactory();
        var incentiveTypeProcessor = incentiveTypeFactory.GetIncentiveTypeBasedOnType(rebate.Incentive);
        return incentiveTypeProcessor.ProcessRebate(rebate, product, request.Volume);
    }
}
