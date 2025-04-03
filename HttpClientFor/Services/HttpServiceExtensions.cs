namespace HttpClientFor.Services;

public static class HttpServiceExtensions

{
    public static IServiceCollection AddMyWorkingWebService(this IServiceCollection services)
    {
        const string baseAddress = "https://localhost:9876/";

        //this order of registration works
        services.AddScoped<IMyWorkingWebService, MyWorkingWebService>();

        services.AddHttpClient<IMyWorkingWebService, MyWorkingWebService>(client =>
            {
                client.BaseAddress = new Uri(baseAddress);
            });

        return services;
    }

    public static IServiceCollection AddMyFailingWebService(this IServiceCollection services)
    {
        const string baseAddress = "https://localhost:4567/";

        services.AddHttpClient<IMyFailingWebService, MyFailingWebService>(client =>
        {
            client.BaseAddress = new Uri(baseAddress);
        });

        //this order of registration fails
        services.AddScoped<IMyFailingWebService, MyFailingWebService>();

        return services;
    }
}
