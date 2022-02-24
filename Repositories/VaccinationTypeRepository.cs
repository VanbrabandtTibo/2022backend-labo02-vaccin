namespace VaccinOefening.Repositories;

public interface IVaccinationTypeRepository
{
    List<VaccinationType> GetVaccinType();
}

public class VaccinationTypeRepository : IVaccinationTypeRepository
{

    private static List<VaccinationType> _types = new List<VaccinationType>();

    public VaccinationTypeRepository()
    {
        if (!(_types.Any()))
        {
            _types.Add(new VaccinationType()
            {
                VaccinTypeId = Guid.Parse("4e2a72fb-f4fa-416f-87cd-ea338b518519"),
                Name = "Pfizer"
            });
            _types.Add(new VaccinationType()
            {
                VaccinTypeId = Guid.Parse("7fa73e42-77d6-4a5b-aef6-0d36779bc989"),
                Name = "Moderna"
            });
        }
    }

    public List<VaccinationType> GetVaccinType()
    {
        return _types.ToList<VaccinationType>();
    }
}
