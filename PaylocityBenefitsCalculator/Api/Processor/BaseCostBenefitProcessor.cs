﻿using Api.Models;

namespace Api.Processor
{
    public class BaseCostBenefitProcessor : IBenefitProcessor
    {
        private readonly decimal _benefitBaseCost;
        public BaseCostBenefitProcessor(IConfiguration configurationRoot) 
        {
            _benefitBaseCost = configurationRoot.GetValue<decimal>("Benefit:BenefitBaseCost");
        }
        public decimal CalculateBenefit(Employee employee)
        {
            return _benefitBaseCost;
        }
    }
}
