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
            if (_paycheckPeriod <= 0)
            {
                throw new Exception("Paycheck Period not set ");            
            }
        }             

        public void Calculate(Paycheck paycheck)
        {
            var salaryPerPaycheck = Math.Round(paycheck.Employee.Salary / _paycheckPeriod, 2, MidpointRounding.ToZero);
            var benefitPerPaycheck = Math.Round(paycheck.TotalBenefitCost / _paycheckPeriod, 2, MidpointRounding.ToZero);
            
            for (var i = 0; i < _paycheckPeriod; i++)
            {
                var monthlyPaycheck = new MonthlyPaycheck
                {
                    BenefitCost = benefitPerPaycheck,
                    Salary = salaryPerPaycheck
                };

                paycheck.MonthlyPaychecks.Add(monthlyPaycheck);
            }            

            var salaryLeftOverAmount = paycheck.Employee.Salary - (salaryPerPaycheck * _paycheckPeriod);
            if(salaryLeftOverAmount > 0) 
            {
                paycheck.MonthlyPaychecks[_paycheckPeriod - 1].Salary = Math.Round(salaryPerPaycheck + salaryLeftOverAmount, 2, MidpointRounding.ToEven);
            }         

            var benefitLeftOverAmount = paycheck.TotalBenefitCost - (benefitPerPaycheck * _paycheckPeriod);
            if (benefitLeftOverAmount > 0)
            {
                paycheck.MonthlyPaychecks[_paycheckPeriod - 1].BenefitCost = Math.Round(benefitPerPaycheck + benefitLeftOverAmount, 2, MidpointRounding.ToEven);
            }
        }       
    }
}
