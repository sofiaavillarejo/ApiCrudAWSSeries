using Amazon.Lambda.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MvcAWSSeriesELB.Data;
using MvcAWSSeriesELB.Repositories;

namespace ApiCrudAWSSeries;

[LambdaStartup]
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", true);

        var configuration = builder.Build();
        services.AddSingleton<IConfiguration>(configuration);

        services.AddTransient<RepositorySeries>();
        string connectionString = configuration.GetConnectionString("MySql");
        services.AddDbContext<SeriesContext>(options => options.UseMySQL(connectionString));
    }
}
