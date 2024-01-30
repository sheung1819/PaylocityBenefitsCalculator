using Api.Models;

namespace Api.Services
{
    public interface IMonthlyPaycheckCalculator
    {
        void Calculate(Paycheck paycheck);
    }
    public class MonthlyPaycheckCalculator : IMonthlyPaycheckCalculator
    {
        private readonly int _paycheckPeriod;
        public MonthlyPaycheckCalculator(IConfiguration configuration) 
        {
            _paycheckPeriod = configuration.GetValue<int>("PaycheckPeriod");
        }             

        public void Calculate(Paycheck paycheck)
        {
            var salaryPerPaycheck = paycheck.Employee.Salary / _paycheckPeriod;
            var benefitPerPaycheck = paycheck.TotalBenefitCost / _paycheckPeriod;
            
            for (var i = 0; i < _paycheckPeriod; i++)
            {
                var monthlyPaycheck = new MonthlyPaycheck
                {
                    BenefitCost = Math.Round(benefitPerPaycheck, 2, MidpointRounding.AwayFromZero),
                    Salary = Math.Round(salaryPerPaycheck, 2, MidpointRounding.AwayFromZero)
                };

                paycheck.MonthlyPaychecks.Add(monthlyPaycheck);
            }

            paycheck.MonthlyPaychecks[_paycheckPeriod - 1].Salary = Math.Round(paycheck.Employee.Salary % _paycheckPeriod + salaryPerPaycheck, 2, MidpointRounding.AwayFromZero);
            paycheck.MonthlyPaychecks[_paycheckPeriod - 1].BenefitCost = Math.Round(paycheck.TotalBenefitCost % _paycheckPeriod + benefitPerPaycheck, 2, MidpointRounding.AwayFromZero);            
        }
    }
}
