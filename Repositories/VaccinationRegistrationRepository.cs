namespace VaccinOefening.Repositories;

public interface IVaccinationRegistrationRepository
{
    void AddRegistration(VaccinationRegistration vaccin);
    List<VaccinationRegistration> GetRegistration();
}

public class VaccinationRegistrationRepository : IVaccinationRegistrationRepository
{
    private static List<VaccinationRegistration> _registrations = new List<VaccinationRegistration>();

    public VaccinationRegistrationRepository()
    {
        if (!(_registrations.Any()))
        {
            _registrations.Add(new VaccinationRegistration()
            {
                VaccinationLocationId = Guid.Parse("2774e3d1-2b0f-47ab-b391-8ea43e6f9d80"),
                Name = "De Preester",
                FirstName = "Dieter",
                EMail = "dieter@preconsult.be",
                YearOfBirth = 1978,
                VaccinationDate = "1/1/2022",
            });
            _registrations.Add(new VaccinationRegistration()
            {
                VaccinationLocationId = Guid.Parse("d2a79300-cdad-44b1-96bd-560361d04cf1"),
                Name = "Vanbrabandt",
                FirstName = "Tibo",
                EMail = "tibo.vanbrabandt@student.howest.be",
                YearOfBirth = 2002,
                VaccinationDate = "10/2/2022",
            });
        }
    }

    public List<VaccinationRegistration> GetRegistration()
    {
        return _registrations.ToList<VaccinationRegistration>();
    }

    public void AddRegistration(VaccinationRegistration vaccin)
    {
        _registrations.Add(vaccin);
    }
}