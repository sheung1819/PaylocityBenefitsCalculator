using Api.Services;

namespace Api.Processor
{
   
    public class EmployeeBenefitProcessorFactory : IProcessorFactory
    {
        private readonly IConfiguration _configuration;
        public EmployeeBenefitProcessorFactory(IConfiguration configuration)
        {
            _configuration = configuration;            
        }
        public IBenefitProcessor? Create(string processorName)
        {
            var type = Type.GetType(processorName);

            if (type == null)
                return null;

            var toReturn = Activator.CreateInstance(type, _configuration);
            return toReturn as IBenefitProcessor;
        }
    }
}
