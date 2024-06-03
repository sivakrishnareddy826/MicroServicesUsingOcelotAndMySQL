using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace OcelotGatewayProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            

            //Add EndpointAPIExplorer to the services
            builder.Services.AddEndpointsApiExplorer();

            // Add Ocelot.json file to the configuration
            builder.Configuration.AddJsonFile("Ocelot.json", optional: false, reloadOnChange:true);

            //Add ocelot to the builder
            builder.Services.AddOcelot(builder.Configuration);
            var app = builder.Build();
            //As it is WebApi project we need configure some middlewares here

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseOcelot().Wait();


            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
