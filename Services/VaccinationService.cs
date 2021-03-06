namespace VaccinOefening.Services;

public interface IVaccinationService
{
    void AddVaccinationRegistrations(VaccinationRegistration vaccin);
    List<VaccinationLocation> GetVaccinationLocations();
    List<VaccinationRegistration> GetVaccinationRegistrations();
    List<VaccinationType> GetVaccinationTypes();
}

public class VaccinationService : IVaccinationService
{

    private readonly IVaccinationLocationRepository _vaccinationLocationRepository;
    private readonly IVaccinationRegistrationRepository _vaccinationRegistrationRepository;
    private readonly IVaccinationTypeRepository _vaccinationTypeRepository;
    private readonly IMailService _mailService;
    public VaccinationService(IVaccinationLocationRepository vaccinationLocationRepository, IVaccinationRegistrationRepository vaccinationRegistration, IVaccinationTypeRepository vaccinationType, IMailService mailService)
    {
        _vaccinationLocationRepository = vaccinationLocationRepository;
        _vaccinationRegistrationRepository = vaccinationRegistration;
        _vaccinationTypeRepository = vaccinationType;
        _mailService = mailService;
    }
    public List<VaccinationLocation> GetVaccinationLocations()
    {
        return _vaccinationLocationRepository.GetLocations();
    }

    public List<VaccinationRegistration> GetVaccinationRegistrations()
    {
        return _vaccinationRegistrationRepository.GetRegistration();
    }

    public void AddVaccinationRegistrations(VaccinationRegistration vaccin)
    {
        _mailService.Send("");
        _vaccinationRegistrationRepository.AddRegistration(vaccin);
    }

    public List<VaccinationType> GetVaccinationTypes()
    {
        return _vaccinationTypeRepository.GetVaccinType();
    }
}