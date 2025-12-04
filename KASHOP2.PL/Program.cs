
using KASHOP.BLL.serveic;
using KASHOP.DAL.DATA;
using KASHOP.DAL.Moadels;
using KASHOP.DAL.Repostriy;
using KASHOP.DAL.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace KASHOP2.PL
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.


            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();
            builder.Services.AddLocalization(options => options.ResourcesPath = "");


            // Test test = new Test();
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

      //builder.Services.AddControllers();
            builder.Services.AddIdentity<Applicationuser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            const string defaultCulture = "en";
            var supportedCultures = new[]
            {
    new CultureInfo(defaultCulture),
    new CultureInfo("ar")
};

            builder.Services.Configure<RequestLocalizationOptions>(options => {
                options.DefaultRequestCulture = new RequestCulture(defaultCulture);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders.Clear();
                options.RequestCultureProviders.Add(new QueryStringRequestCultureProvider
                {
                    QueryStringKey = "lang"
                });
            });
            // Categoryserveic: ICategoryService
            // Categoryrepostry: IcategoryRepstriy
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
             builder.Services.AddScoped<IcategoryRepstriy, Categoryrepostry>();
          //  builder.Services.AddScoped<Categoryrepostry>();
            builder.Services.AddScoped<ICategoryService, Categoryserveic>();
            builder.Services.AddScoped<ISeedData,RoleSeedData>();
            builder.Services.AddScoped<ISeedData,UserSeedData>();
            builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
            var app = builder.Build();
            app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var seeders = services.GetServices<ISeedData>();
                foreach (var seeder in seeders)
                {
                    await seeder.DataSeed();
                }
            }
            app.MapControllers();

            app.Run();
        }
    }
}
