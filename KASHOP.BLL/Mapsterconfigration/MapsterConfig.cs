using KASHOP.DAL.DTOS.Response.catgores;
using KASHOP.DAL.DTOS.Response.Proudct;
using KASHOP.DAL.Moadels.catgores;
using KASHOP.DAL.Moadels.Proudct;
using KASHOP.DAL.Repostriy;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.Mapsterconfigration
{
    public  static class MapsterConfig
    {
        public static  void MapsterConfigRegsiter()
        {
            TypeAdapterConfig<Categores, Responsecategory>
            .NewConfig().Map(dest => dest.CreatedBy, src => src.User.UserName);

            TypeAdapterConfig<Categores,CatgoryUserResponse>.NewConfig()
    .Map(dest => dest.Name, source => source.translations
    .Where(t => t.Language == MapContext.Current.Parameters["lang"].ToString())
    .Select(t => t.Name).FirstOrDefault());
            //image link 
            TypeAdapterConfig<Product, ProductResponse>.NewConfig()
    .Map(dest => dest.MainImage, source => $"https://localhost:7293/images/{source.MainImage}");


            TypeAdapterConfig<Product, ProudctsuserResponse>.NewConfig()
                .Map(dest => dest.MainImage, source => $"https://localhost:7293/images/{source.MainImage}")
   
                .Map(dest => dest.Name, source => source.Translations

   .Where(t => t.Language == MapContext.Current.Parameters["lang"].ToString())
   .Select(t => t.Name).FirstOrDefault());


            TypeAdapterConfig<Product, ProductUserDetails>.NewConfig()
    .Map(dest => dest.Name, source => source.Translations
    .Where(t => t.Language == MapContext.Current.Parameters["lang"].ToString())
    .Select(t => t.Name).FirstOrDefault())
            .Map(dest => dest.Description, source => source.Translations
    .Where(t => t.Language == MapContext.Current.Parameters["lang"].ToString())
    .Select(t => t.Description).FirstOrDefault());

        }
    }
}
