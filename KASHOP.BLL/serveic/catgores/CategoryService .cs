using KASHOP.DAL.DTOS.Request.Catgores;
using KASHOP.DAL.DTOS.Response.catgores;
using KASHOP.DAL.DTOS.Response.classbase;
using KASHOP.DAL.Moadels.catgores;
using KASHOP.DAL.Repostriy;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.serveic.catgores
{
    public class Categoryserveic : ICategoryService
    {
        private readonly IcategoryRepstriy _categoryrepostry;

        public Categoryserveic(IcategoryRepstriy categoryrepostry)
        {
            _categoryrepostry = categoryrepostry;
        }
        public async Task<Responsecategory> createl_categres(CategoryRequest request)
        {
            var category = request.Adapt<Categores>();
            

              await _categoryrepostry.createAsync(category);
            return category.Adapt<Responsecategory>();
        }

        public  async Task <List<Responsecategory>> Getall_categres_forAdmin()
        {
            var categories =  await _categoryrepostry.GetAllAsync();
           
            var response = categories.Adapt<List<Responsecategory>>();
            return response;
        }
        public async Task<List<CatgoryUserResponse>> Getall_categres_forUser(string lang = "en")
        {
            var categories = await _categoryrepostry.GetAllAsync();
            /*  var response = categories.Select(c => new CatgoryUserResponse
              {
                  Id = c.Id,
                  Name = c.translations.Where(t => t.Language == lang).Select(t => t.Name).FirstOrDefault()
              }).ToList();*/
            var response = categories.BuildAdapter().AddParameters("lang", lang).AdaptToType<List<CatgoryUserResponse>>();
            return response;
        }
        public async Task<BaseResponse> ToggleStatus(int id)
        {
            try
            {
                var category = await _categoryrepostry.FindByIdAsync(id);
                if (category is null)
                {
                    return new BaseResponse
                    {
                        Success = false,
                        messages = "Category Not Found"
                    };
                }

                category.status = category.status == Status.Active ? Status.Inactive : Status.Active;
                await _categoryrepostry.UpdateAsync(category);

                return new BaseResponse
                {
                    Success = true,
                    messages = "Category Updated Successfully"
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    Success = false,
                    messages = "Can't Toggle Category Status",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
        public async Task<BaseResponse> DeleteCategoryAsync(int id)
        {
            try
            {
                var category = await _categoryrepostry.FindByIdAsync(id);
                if (category is null)
                {
                    return new BaseResponse
                    {
                        Success = false,
                        messages = "Category Not Found"
                    };
                }

                await _categoryrepostry.DeleteAsync(category);

                return new BaseResponse
                {
                    Success = true,
                    messages = "Category deleted successfully"
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    Success = false,
                    messages = "Can't Delete Category",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
        public async Task<BaseResponse> UpdateCategoryAsync(int id, CategoryRequest request)
        {
            try
            {
                var category = await _categoryrepostry.FindByIdAsync(id);
                if (category is null)
                {
                    return new BaseResponse
                    {
                        Success = false,
                        messages = "Category Not Found"
                    };
                }
                if (request.translations != null && request.translations.Any())
                {
                    foreach (var translation in request.translations)
                    {
                        var existing = category.translations
                            .FirstOrDefault(t => t.Language == translation.Language);

                        if (existing is not null)
                        {
                            existing.Name = translation.Name;
                        }

                        else
                        {
                            return new BaseResponse
                            {
                                Success = false,
                                messages = $"Language '{translation.Language}' not supported"
                            };
                        }
                    }

                }
                await _categoryrepostry.UpdateAsync(category);

                return new BaseResponse
                {
                    Success = true,
                    messages = "Category updated successfully"
                };
            }
            catch (Exception ex)
            {
                return new BaseResponse
                {
                    Success = false,
                    messages = "Can't Update Category",
                    Errors = new List<string> { ex.Message }
                };
            }
        }
    }
}
