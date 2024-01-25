using Api.Dtos.Dependent;

namespace Api.Services
{
    public interface IDependentService
    {
        IEnumerable<GetDependentDto> GetDependents();
        GetDependentDto? GetDependentByID(int id);
    }
}
