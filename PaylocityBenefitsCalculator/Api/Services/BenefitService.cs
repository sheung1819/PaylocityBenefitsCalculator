using Api.Models;
using Api.Processor;
using System.Collections.Concurrent;

namespace Api.Services
{
    public class BenefitService : IBenefitService
    {        
        private readonly IProcessorFactory _employeeProcessor;
        private readonly IProcessorFactory _dependentProcessor;
        private const string ProcessorNameSpace = "Api.Processor.";

        public BenefitService([FromKeyedServices("EmployeeProcessor")] IProcessorFactory employeeProcessor,
            [FromKeyedServices("DependentProcessor")] IProcessorFactory dependentProcessor)
        {
            _employeeProcessor = employeeProcessor;
            _dependentProcessor = dependentProcessor;
        }

        public decimal Calculate(Employee employee)
        { 
            var benefitProcessors = new List<IBenefitProcessor?>();

            AddEmployeeBenefitProcessor(benefitProcessors);
            AddDependentBenefitProcessor(employee, benefitProcessors);          

            return ProcessBenefit(employee, benefitProcessors);
           
        }

        private void AddDependentBenefitProcessor(Employee employee, List<IBenefitProcessor?> benefitProcessors)
        {
            if (employee.Dependents.Any())
            {
                benefitProcessors.Add(_dependentProcessor.Create(ProcessorNameSpace + "DependentAgeBenefitProcessor"));
                benefitProcessors.Add(_dependentProcessor.Create(ProcessorNameSpace + "DependentCountBenefitProcessor"));
            }
        }

        private void AddEmployeeBenefitProcessor(List<IBenefitProcessor?> benefitProcessors)
        {
            benefitProcessors.Add(_employeeProcessor.Create(ProcessorNameSpace + "BaseCostBenefitProcessor"));
            benefitProcessors.Add(_employeeProcessor.Create(ProcessorNameSpace + "EmployeeSalaryBenefitProcessor"));
        }

        private static decimal ProcessBenefit(Employee employee, List<IBenefitProcessor?> processors)
        {
            var benefitCost = new ConcurrentBag<decimal>();

            Parallel.ForEach(processors, processor =>
            {
                if(processor != null)
                    benefitCost.Add(processor.CalculateBenefit(employee));
            });

            return benefitCost.ToList().Sum();
        }
    }
}
