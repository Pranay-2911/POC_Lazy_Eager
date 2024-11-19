
using Microsoft.EntityFrameworkCore;
using POC_Lazy_Eager.Data;
using POC_Lazy_Eager.Repositories;
using POC_Lazy_Eager.Services;
using System.Text.Json.Serialization;

namespace POC_Lazy_Eager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<DirectorContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("ConnString"))
                .UseLazyLoadingProxies(); // Enables Lazy Loading 

            });

            //builder.Services.AddAutoMapper(typeof(MapperProfile));
            builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddTransient<IDirectorService, DirectorService>();

            builder.Services.AddControllers().AddJsonOptions(x =>
            {
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
