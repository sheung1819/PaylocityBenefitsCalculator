using Api.Dtos.Employee;
using Api.Dtos.MonthlyPaycheck;
using Api.Dtos.Paycheck;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace ApiTests.IntegrationTests
{
    public class PaycheckIntegrationTests : IntegrationTest
    {
        [Fact]       
        public async Task WhenAskedForPaycheckCalculation_ShouldReturnCorrectPaycheckPeriod()
        {
            var response = await HttpClient.GetAsync("/api/v1/paycheck/1");
            var paycheck = new GetPaycheckDto
            {
                Employee = new GetEmployeeDto
                {
                    Id = 1,
                    FirstName = "LeBron",
                    LastName = "James",
                    Salary = 75420.99m,
                    DateOfBirth = new DateTime(1984, 12, 30)
                },
                TotalBenefitCost = 1000,
                MonthlyPaychecks = new List<GetMonthlyPaycheckDto>
                { 
                    new GetMonthlyPaycheckDto
                    { 
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                    new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                    new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                    new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                    new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                    new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                    new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                    new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                    new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                    new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                    new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                    new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                    new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                    new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                    new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                    new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                    new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                    new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                    new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                    new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                    new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                    new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                     new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                      new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                       new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 38.46m,
                        Salary = 2900.81m
                    },
                     new GetMonthlyPaycheckDto
                    {
                        BenefitCost = 50.46m,
                        Salary = 2921.80m
                    },
                }
            };
            await response.ShouldReturn(HttpStatusCode.OK, paycheck);
        }
    }
}
