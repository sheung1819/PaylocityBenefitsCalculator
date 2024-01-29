using Api.Processor;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiTests.UnitTests
{
    public class PaycheckServiceTests
    {
        private Mock<BaseCostBenefitProcessor> _mockBaseCost;
        private List<IBenefitProcessor> _processors;
        public PaycheckServiceTests() 
        {
            _mockBaseCost = (new Mock<BaseCostBenefitProcessor>());

            _processors.Add(_mockBaseCost.Object);

        
        }


        [Fact]
        public void PaycheckService_Should_Calculate_Monthly_Paycheck()
        { 

            
        }

        
        
    }
}
