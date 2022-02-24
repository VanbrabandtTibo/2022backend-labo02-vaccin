var builder = WebApplication.CreateBuilder(args);
var csvSettings = builder.Configuration.GetSection("CsvConfig");
builder.Services.Configure<CsvConfig>(csvSettings);

builder.Services.AddTransient<IVaccinationLocationRepository, CsvLocationRepository>();
builder.Services.AddTransient<IVaccinationRegistrationRepository, VaccinationRegistrationRepository>();
builder.Services.AddTransient<IVaccinationTypeRepository, VaccinationTypeRepository>();

builder.Services.AddTransient<IVaccinationService, VaccinationService>();
builder.Services.AddTransient<IMailService,OutLookService>();

builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

app.UseExceptionHandler(c => c.Run(async context =>
{
    var exception = context.Features
        .Get<IExceptionHandlerFeature>()
        ?.Error;
    if (exception is not null)
    {
        var response = new { error = exception.Message };
        context.Response.StatusCode = 400;

        await context.Response.WriteAsJsonAsync(response);
    }
}));

//GET
app.MapGet("/", () => "Hello World!");

app.MapGet("/locations", (IVaccinationService vaccinationService) => {
    return Results.Ok(vaccinationService.GetVaccinationLocations());
});

app.MapGet("/registrations", (IMapper mapper, IVaccinationService vaccinationService) =>
{
    try
    {
        var mapped = mapper.Map<List<VaccinRegistrationDTO>>(vaccinationService.GetVaccinationRegistrations());
        return Results.Ok(mapped);
    }
    catch (Exception ex){
        Console.WriteLine(ex);
        throw;
    }
});
    
app.MapGet("/types", (IVaccinationService vaccinationService) => {
    return Results.Ok(vaccinationService.GetVaccinationTypes());
});

//POST
app.MapPost("/registrations", (IVaccinationService vaccinationService, VaccinationRegistration registration) => {
    try
    {
        vaccinationService.AddVaccinationRegistrations(registration);
        return Results.Ok();
    }
    catch (System.Exception ex)
    {
        Console.WriteLine(ex);
        return Results.BadRequest(ex);
    }
});

app.Run("http://localhost:3000");