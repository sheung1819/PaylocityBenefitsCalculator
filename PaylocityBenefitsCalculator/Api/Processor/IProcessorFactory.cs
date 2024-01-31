namespace Api.Processor
{
    public interface IProcessorFactory
    {
        IBenefitProcessor? Create(string processorName);
    }   
}
