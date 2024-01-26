namespace Api.Models
{
    public class Paycheck
    {
        public Employee Employee { get; set; } = new Employee();
        public decimal TotalBenefitCost { get; set; }        
        public IList<MonthlyPaycheck> MonthlyPaychecks { get; set; } = new List<MonthlyPaycheck>();
    }
    public class MonthlyPaycheck
    { 
        public decimal BenefitCost { get; set; }    
        public decimal Salary { get; set; }    
    }
}
