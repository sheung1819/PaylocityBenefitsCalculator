using Api.Models;
using Api.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiTests.UnitTests
{
    public class MonthlyPaycheckCalculatorTests
    {
        [Fact]
        public void WhenCalculateMontlyPaycheck_ShouldReturnCorrectNumberOfPayPeriod()
        { 
            var calculator = new MonthlyPaycheckCalculator(ConfigurationHelper.Configuration);
            var paycheck = new Paycheck();
            paycheck.Employee.Salary = 100;
            paycheck.TotalBenefitCost = 100;

            calculator.Calculate(paycheck);

            var expectedPeriod = ConfigurationHelper.Configuration.GetValue<int>("PaycheckPeriod");


            Assert.True(paycheck.MonthlyPaychecks.Count == expectedPeriod);
        }
        [Fact]
        public void WhenCalculateMonthlyPaycheck_PaycheckShouldDivideEvenly()
        {
            var calculator = new MonthlyPaycheckCalculator(ConfigurationHelper.Configuration);
            var paycheck = new Paycheck();
            paycheck.Employee.Salary = 1000;
            paycheck.TotalBenefitCost = 100;
            calculator.Calculate(paycheck);
            Assert.DoesNotContain(paycheck.MonthlyPaychecks, x => x.Salary != 200);
            Assert.DoesNotContain(paycheck.MonthlyPaychecks, x => x.BenefitCost != 20);
        }

        [Fact]
        public void WhenCalculateMonthlyPaycheck_IfAmountIsNotDivideEvenlyAddToLastPaycheckPeriod()
        {
            var calculator = new MonthlyPaycheckCalculator(ConfigurationHelper.Configuration);
            var paycheck = new Paycheck();
            paycheck.Employee.Salary = 143.13m;
            paycheck.TotalBenefitCost = 100;
            calculator.Calculate(paycheck);

            var lastPaycheckPeriod = ConfigurationHelper.Configuration.GetValue<int>("PaycheckPeriod") - 1;
            Assert.True(paycheck.MonthlyPaychecks[lastPaycheckPeriod].Salary == 28.65m);
        }
    }
}
