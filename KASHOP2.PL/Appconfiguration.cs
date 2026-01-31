using KASHOP.BLL.serveic.auth;
using KASHOP.BLL.serveic.catgores;
using KASHOP.BLL.serveic.Fileserveis;
using KASHOP.BLL.serveic.Proudct;
using KASHOP.DAL.Repostriy.Catgores;
using KASHOP.DAL.Repostriy.Proudcts;
using KASHOP.DAL.Utils;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace KASHOP.PL
{
    public static class Appconfiguration
    {
        public static void   Config(IServiceCollection services)
        {

            services.AddScoped<IcategoryRepstriy, Categoryrepostry>();
            //  builder.Services.AddScoped<Categoryrepostry>();
            services.AddScoped<ICategoryService, Categoryserveic>();
            services.AddScoped<ISeedData, RoleSeedData>();
            services.AddScoped<ISeedData, UserSeedData>();
            services.AddScoped<IEmailSender, EmailSender>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<Ifileservice, FileService>();
            services.AddScoped<IProudctServeic, ProudctServeic>();
            services.AddScoped<IProudctsRepsotry, ProudctRepostry>();

        }
    }
}