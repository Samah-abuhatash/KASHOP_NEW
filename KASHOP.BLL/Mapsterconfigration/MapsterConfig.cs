using KASHOP.DAL.DTOS.Response;
using KASHOP.DAL.Moadels;
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
        }
    }
}
