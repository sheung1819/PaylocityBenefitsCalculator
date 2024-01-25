namespace Api.Services
{
    public interface IMonthlyPaycheckCalculator
    {
        IList<decimal> Calculate(decimal amount);
    }
    public class MonthlyPaycheckCalculator : IMonthlyPaycheckCalculator
    {
        private readonly int _paycheckPeriod = 26;

        public IList<decimal> Calculate(decimal amount)
        {
            var remain = amount % _paycheckPeriod;
            var monthlyAmount = new List<decimal>();
            var perPaycheckAmonnt = amount / _paycheckPeriod;
            for (var i = 0; i < _paycheckPeriod; i++)
            {
                monthlyAmount.Add(perPaycheckAmonnt);
            }

            if (remain == 0) 
            {
                return monthlyAmount;
            }

            // Adding the remaining to the last paycheck 
            monthlyAmount[_paycheckPeriod - 1] = perPaycheckAmonnt + remain;
            return monthlyAmount;
        }
    }
}
