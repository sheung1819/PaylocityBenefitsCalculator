using Api.Models;

namespace Api.Services
{
    public interface IDependentQualifyService
    { 
        int GetDependentCount(Employee employee);
    }
    public class DependentQualifyService : IDependentQualifyService
    {
        private readonly IList<string> _dependentRelationship;
        public DependentQualifyService(IConfiguration configuration)
        {
            var relationship = configuration.GetValue<string>("Benefit:QualifyDependentRelationType");

            if (relationship == null)
            {
                throw new Exception("Qualify Dependent Relation Type is not set in app setting");
            }

            _dependentRelationship = relationship.Split(",");

        }
        public int GetDependentCount(Employee employee)
        {
            return employee.Dependents.Select(x => !_dependentRelationship.Contains(x.Relationship.ToString())).Count();
        }
    }
}
