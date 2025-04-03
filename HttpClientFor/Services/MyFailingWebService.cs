namespace HttpClientFor.Services;

public class MyFailingWebService : IMyFailingWebService
{
    private readonly HttpClient httpClient;

    public MyFailingWebService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public string TellMeBaseAddress()
    {
        return httpClient.BaseAddress?.ToString() ?? "No BaseAddress";
    }
}
