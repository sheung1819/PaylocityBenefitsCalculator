using Api.Models;

namespace Api.Services
{
    public interface IMonthlyPaycheckCalculator
    {
        void Calculate(Paycheck paycheck);
    }
    public class MonthlyPaycheckCalculator : IMonthlyPaycheckCalculator
    {
        private readonly int _paycheckPeriod = 26;     

        public void Calculate(Paycheck paycheck)
        {
            var salaryPerPaycheck = paycheck.Employee.Salary / _paycheckPeriod;
            var benefitPerPaycheck = paycheck.TotalBenefitCost / _paycheckPeriod;
            
            for (var i = 0; i < _paycheckPeriod; i++)
            {
                var monthlyPaycheck = new MonthlyPaycheck
                {
                    BenefitCost = benefitPerPaycheck,
                    Salary = salaryPerPaycheck,
                };

                paycheck.MonthlyPaychecks.Add(monthlyPaycheck);
            }

            paycheck.MonthlyPaychecks[_paycheckPeriod - 1].Salary = paycheck.Employee.Salary % _paycheckPeriod + salaryPerPaycheck;
            paycheck.MonthlyPaychecks[_paycheckPeriod - 1].BenefitCost = paycheck.TotalBenefitCost % _paycheckPeriod + benefitPerPaycheck;
            
        }
    }
}
