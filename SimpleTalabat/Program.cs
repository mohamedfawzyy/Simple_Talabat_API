using Microsoft.EntityFrameworkCore;
using Talabat.Core.Repositories.Contract;
using Talabat.Repository;
using Talabat.Repository.Data;
using Talabat.Repository.Data.DataSeeding;

namespace SimpleTalabat
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region ConfigureServices
                    // Add services to the container.
                    builder.Services.AddControllers();
                    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                    builder.Services.AddEndpointsApiExplorer();
                    builder.Services.AddSwaggerGen();
                    //allow Dependancy injection for DbContextOptions
                    builder.Services.AddDbContext<StoreContext>(
                    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Default_Connection")));
                    //allow Dependancy injection for GenericRepository any Type of IGeneric return GenericRepository
                    builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>)); 
            #endregion


            var app = builder.Build();
            //allow Depedancy injection explicity
            using var Scope= app.Services.CreateScope();  //using to close Scope that we opened 
            var Services = Scope.ServiceProvider;
            var _dbContext = Services.GetRequiredService<StoreContext>();  //an object from DBContxt
            var LoggerFactory = Services.GetRequiredService<ILoggerFactory>();   //an object form ILooger

            try
            {
                await _dbContext.Database.MigrateAsync(); //updata-database
                await StoreContextSeed.SeedData(_dbContext); //seed data
            }
            catch (Exception ex)
            {

                var Logger = LoggerFactory.CreateLogger<Program>();
                Logger.LogError("Error Has Occured "+  ex.Message);
            }

            #region Configure Kastrel MiddleWare
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            #endregion

            app.Run();
        }
    }
}
