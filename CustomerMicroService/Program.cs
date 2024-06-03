
using CustomerMicroService.Data;
using CustomerMicroService.Repository;
using Microsoft.EntityFrameworkCore;

namespace CustomerMicroService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            //Adding services to the Db
            string? conn = builder.Configuration.GetConnectionString("CustomerDb");
            builder.Services.AddDbContext<CustomerDbContext>(options =>
            options.UseMySql(conn, ServerVersion.AutoDetect(conn)));

            // Injecting services to the container
            builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
