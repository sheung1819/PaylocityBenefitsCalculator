using Api.Models;
using Api.Services;
using System.Collections.Generic;
using System.Linq;
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
            var dependents = service.GetDependents(employee);
            Assert.True(dependents.Count() == 2);
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
            var dependents = service.GetDependents(employee);
            Assert.True(!dependents.Any());
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
            var dependents = service.GetDependents(employee);
            Assert.True(dependents.Count() == 1);
        }
    }
}
