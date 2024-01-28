using Api.Models;
using Api.Processor;
using Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiTests.UnitTests
{
    public class DependentQualifyServiceTests
    {
        [Fact]
        public void DependentQualityService_Should_Return_Dependent_Count_For_Child()
        {
            var service = new DependentQualifyService(ConfigurationHelper.Configuration);

            var employee = new Employee
            {
                Dependents = new List<Dependent>
                { 
                    new Dependent 
                        {
                            Relationship = Relationship.Child
                        },
                    new Dependent
                        {
                            Relationship = Relationship.Child
                        }
                }
            };
            var dependentCount = service.GetDependentCount(employee);
            Assert.True(dependentCount == 2);
        }
    }
}
