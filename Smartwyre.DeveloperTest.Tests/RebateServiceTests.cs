using FakeItEasy;
using NUnit.Framework;
using Smartwyre.DeveloperTest.Interface;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Tests
{
    [TestFixture]
    public class RebateServiceTests
    {
        private RebateService _rebateService;
        private IRebateDataStore _rebateDataStore;
        private IProductDataStore _productDataStore;

        [SetUp]
        public void SetUp()
        {
            _rebateDataStore = A.Fake<IRebateDataStore>();
            _productDataStore = A.Fake<IProductDataStore>();
            _rebateService = new RebateService(_rebateDataStore, _productDataStore);
        }

        [Test]
        public void WhenProcessRequestIsCalled_WithValidRequest_ShouldReturnValidResult()
        {
            var request = new CalculateRebateRequest
            {
                Volume = 30,
                ProductIdentifier = "Test"
            };

            A.CallTo(() => _rebateDataStore.GetRebate(A<string>.Ignored))
                .Returns(
                new Rebate { Amount = 44, Percentage = 40, Identifier = "FixedRateRebate" });

            A.CallTo(() => _productDataStore.GetProduct(A<string>.Ignored))
                .Returns(
                new Product { Price = 44, SupportedIncentives = SupportedIncentiveType.FixedRateRebate });

            var result = _rebateService.ProcessRequest(request);

            Assert.AreEqual(true, result.Success);
        }

        [Test]
        public void WhenProcessRequestIsCalledWithInvalidRebateIdentifier_ShouldReturnInvalidResult()
        {
            A.CallTo(() => _rebateDataStore.GetRebate(A<string>.Ignored))
                .Returns(null);

            A.CallTo(() => _productDataStore.GetProduct(A<string>.Ignored))
                .Returns(
                new Product { Price = 44, SupportedIncentives = SupportedIncentiveType.FixedRateRebate });

            var result = _rebateService.ProcessRequest(new CalculateRebateRequest());

            Assert.AreEqual(false, result.Success);
        }

    }
}
