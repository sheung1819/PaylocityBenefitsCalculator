using Api.Models;
using Api.Services;
using System.Collections.Generic;
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

        [Fact]
        public void DependentQualityService_Should_Return_NO_Dependent_Count_For_Non_Child()
        {
            var service = new DependentQualifyService(ConfigurationHelper.Configuration);

            var employee = new Employee
            {
                Dependents = new List<Dependent>
                {
                    new Dependent
                        {
                            Relationship = Relationship.None
                        },
                    new Dependent
                        {
                            Relationship = Relationship.Spouse
                        }
                }
            };
            var dependentCount = service.GetDependentCount(employee);
            Assert.True(dependentCount == 0);
        }

        [Fact]
        public void DependentQualityService_Should_Return_NO_Dependent_Count_For_Child_Only()
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
                            Relationship = Relationship.Spouse
                        }
                }
            };
            var dependentCount = service.GetDependentCount(employee);
            Assert.True(dependentCount == 1);
        }
    }
}
