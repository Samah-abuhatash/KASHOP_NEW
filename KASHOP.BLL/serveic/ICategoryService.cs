using KASHOP.DAL.DTOS.Request;
using KASHOP.DAL.DTOS.Response;
using KASHOP.DAL.Moadels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.serveic
{
    public interface ICategoryService
    {
        Task<List<Responsecategory>> Getall_categres_forAdmin();
        Task<Responsecategory> createl_categres(CategoryRequest request);
        Task<BaseResponse> DeleteCategoryAsync(int id);
        Task<BaseResponse> UpdateCategoryAsync(int id, CategoryRequest request);
        Task<BaseResponse> ToggleStatus(int id);
        Task<List<CatgoryUserResponse>> Getall_categres_forUser(string lang = "en");

    }
}