namespace VaccinOefening.DTO;
public class DTOProfile : Profile
{
    public DTOProfile()
    {
        CreateMap<VaccinationRegistration, VaccinRegistrationDTO>()
        .ForMember(dest => dest.VaccinName , opt => opt.MapFrom<VaccinResolver>())
        .ForMember(dest => dest.Location , opt => opt.MapFrom<VaccinLocationResolver>());
    }
}

public class VaccinLocationResolver : IValueResolver<VaccinationRegistration, VaccinRegistrationDTO,string>
{
    private readonly IVaccinationService _service;

    public VaccinLocationResolver(IVaccinationService service){
        _service = service;
    }
    public string Resolve(VaccinationRegistration source, VaccinRegistrationDTO destination,string dest, ResolutionContext context)
    {
        return _service.GetVaccinationLocations().Where(l => l.VaccinationLocationId == source.VaccinatinRegistrationId).First().Name;
        //List<VaccinationLocation> locations = context.Items["locations"] as List<VaccinationLocation>;
        //return locations.Where(l => l.VaccinationLocationId == source.VaccinationLocationId).Single().Name;
    }
}

public class VaccinResolver : IValueResolver<VaccinationRegistration, VaccinRegistrationDTO,string>
{
    public string Resolve(VaccinationRegistration source, VaccinRegistrationDTO destination,string dest, ResolutionContext context)
    {
        List<VaccinationType> vaccins = context.Items["vaccins"] as List<VaccinationType>;
        return vaccins.Where(l => l.VaccinTypeId == source.VaccinTypeId).Single().Name;
    }
}