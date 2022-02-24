namespace VaccinOefening.Services;

public interface IMailService
{
    void Send(string to);
}

public class OutLookService : IMailService
{
    public void Send(string to)
    {
        //echte code
    }
}

public class GMailService : IMailService
{
    public void Send(string to)
    {
        //echte code
    }
}