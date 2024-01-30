namespace Api.Dtos.MonthlyPaycheck
{
    public class GetMonthlyPaycheckDto
    {
        public decimal BenefitCost { get; set; }
        public decimal Salary { get; set; }
        public decimal SalaryAfterBenefitCost => Salary - BenefitCost;
    }
}
