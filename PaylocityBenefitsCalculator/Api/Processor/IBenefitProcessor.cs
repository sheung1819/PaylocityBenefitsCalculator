using Api.Models;

namespace Api.Processor
{
    public interface IBenefitProcessor
    {
        decimal CalculateBenefit(Employee employee);
    }
}
