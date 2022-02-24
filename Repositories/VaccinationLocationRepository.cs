namespace VaccinOefening.Repositories;

public interface IVaccinationLocationRepository
{
    List<VaccinationLocation> GetLocations();
}

public class VaccinationLocationRepository : IVaccinationLocationRepository
{

    private static List<VaccinationLocation> _locations = new List<VaccinationLocation>();

    public VaccinationLocationRepository()
    {
        if (!(_locations.Any()))
        {
            _locations.Add(new VaccinationLocation()
            {
                VaccinationLocationId = Guid.Parse("2774e3d1-2b0f-47ab-b391-8ea43e6f9d80"),
                Name = "Kortrijk Expo"
            });
            _locations.Add(new VaccinationLocation()
            {
                VaccinationLocationId = Guid.Parse("0bb537ea-8209-422f-a9e1-2c1e37d0cb4d"),
                Name = "Gent Expo"
            });
        }
    }

    public List<VaccinationLocation> GetLocations()
    {
        return _locations.ToList<VaccinationLocation>();
    }
}

public class CsvLocationRepository : IVaccinationLocationRepository
{
    private readonly CsvConfig _config;
    public CsvLocationRepository(IOptions<CsvConfig> config)
    {
        _config = config.Value;
    }
    public List<VaccinationLocation> GetLocations()
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            Delimiter = ";",
        };
        using (var reader = new StreamReader(_config.LocationPath))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            var records = csv.GetRecords<VaccinationLocation>();
            return records.ToList();
        }
    }
}