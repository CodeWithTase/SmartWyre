using Smartwyre.DeveloperTest.Interface;
using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;

namespace Smartwyre.DeveloperTest.Factories
{
    internal class IncentiveTypeFactory
    {

        private Dictionary<IncentiveType, Func<IIncentiveType>> _incentiveTypeMapper;

        public IncentiveTypeFactory()
        {
            _incentiveTypeMapper = new Dictionary<IncentiveType, Func<IIncentiveType>>
            {
                {
                    IncentiveType.AmountPerUom,
                    () => { return new AmountPerUomProcessor(); }
                },
                {
                    IncentiveType.FixedRateRebate,
                    () => { return new FixedRateRebateProcessor(); }
                },
                {
                    IncentiveType.FixedCashAmount,
                    () => { return new FixedCashAmountProcessor(); }
                }
            };
        }

        public IIncentiveType GetIncentiveTypeBasedOnType(IncentiveType incentiveType) =>
            _incentiveTypeMapper[incentiveType]();

    }
}
