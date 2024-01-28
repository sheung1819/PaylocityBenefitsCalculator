using Api.Models;

namespace Api.Services
{
    public interface IDependentQualifyService
    {
        IEnumerable<Dependent> GetDependents(Employee employee);
    }
    public class DependentQualifyService : IDependentQualifyService
    {
        private readonly IList<string> _dependentRelationship;
        public DependentQualifyService(IConfiguration configuration)
        {
            var relationship = configuration.GetValue<string>("Benefit:QualifyDependentRelationType") ?? throw new Exception("Qualify Dependent Relation Type is not set in app setting");
            _dependentRelationship = relationship.Split(",");

        }
        public IEnumerable<Dependent> GetDependents(Employee employee)
        {
            return employee.Dependents.Where(x => _dependentRelationship.Contains(x.Relationship.ToString()));
        }
    }
}
