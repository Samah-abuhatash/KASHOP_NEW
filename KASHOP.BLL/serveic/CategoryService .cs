using KASHOP.DAL.DTOS.Request;
using KASHOP.DAL.DTOS.Response;
using KASHOP.DAL.Moadels;
using KASHOP.DAL.Repostriy;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.serveic
{
    public class Categoryserveic : ICategoryService
    {
        private readonly IcategoryRepstriy _categoryrepostry;

        public Categoryserveic(IcategoryRepstriy categoryrepostry)
        {
            _categoryrepostry = categoryrepostry;
        }
        public Responsecategory createl_categres(CategoryRequest request)
        {
            var category = request.Adapt<Categores>();
           
            _categoryrepostry.create(category);
            return category.Adapt<Responsecategory>();
        }

        public List<Responsecategory> Getall_categres()
        {
            var categories = _categoryrepostry.Getall();
            var response = categories.Adapt<List<Responsecategory>>();
            return response;
        }
    }
}
