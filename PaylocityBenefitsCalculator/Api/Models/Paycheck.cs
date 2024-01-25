namespace Api.Models
{
    public class MonthlyPaycheck
    {             
        public decimal Salary { get; set; }
        public decimal BenefitCost { get; set; }
        public decimal SalaryAfterBenefitCost => Salary - BenefitCost; 
       
    }
}
