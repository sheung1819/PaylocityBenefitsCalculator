using Api.Models;

namespace Api.Services
{
    public interface IDependentIdentifierService
    { 
        int GetDependentCount(Employee employee);
    }
    public class DependentIdentifierService : IDependentIdentifierService
    {
        private readonly IList<string> _dependentRelationship;
        public DependentIdentifierService(IConfiguration configuration)
        {
            var relationship = configuration.GetValue<string>("QualifyDependentRelationType");

            _dependentRelationship = relationship.Split(",");

        }
        public int GetDependentCount(Employee employee)
        {
            return employee.Dependents.Select(x => !_dependentRelationship.Contains(x.Relationship.ToString())).Count();
        }
    }
}
