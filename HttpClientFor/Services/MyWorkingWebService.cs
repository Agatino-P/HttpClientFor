namespace HttpClientFor.Services;

public class MyWorkingWebService : IMyWorkingWebService
{
    private readonly HttpClient httpClient;

    public MyWorkingWebService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public string TellMeBaseAddress()
    {
        return httpClient.BaseAddress?.ToString() ?? "No BaseAddress";
    }
}