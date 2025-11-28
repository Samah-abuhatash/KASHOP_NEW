using KASHOP.DAL.DTOS.Response;
using KASHOP.DAL.Moadels;
using KASHOP.DAL.Repostriy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using KASHOP.DAL.DTOS.Request;

namespace KASHOP.BLL.serveic
{
    public class Categoryserveic : ICategoryService
    {
        private readonly Categoryrepostry _categoryrepostry;

        public Categoryserveic(Categoryrepostry categoryrepostry)
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
