using Api.Services;

namespace Api.Processor
{
    public interface IProcessorFactory
    {
        IBenefitProcessor? Create(string processorName);
    }
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

    public class DependentBenefitProcessorFactory : IProcessorFactory
    {
        private IConfiguration _configuration;
        private readonly IDependentQualifyService _qualifyService;
        public DependentBenefitProcessorFactory(IConfiguration configuration, IDependentQualifyService dependentQualifyService)
        {
            _configuration = configuration;
            _qualifyService = dependentQualifyService;
        }
        public IBenefitProcessor? Create(string processorName)
        {
            var type = Type.GetType(processorName);

            if (type == null)
                return null;

            var toReturn = Activator.CreateInstance(type, _configuration, _qualifyService);
            return toReturn as IBenefitProcessor;
        }
    }
}
