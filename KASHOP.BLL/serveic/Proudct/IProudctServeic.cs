using KASHOP.DAL.DTOS.Request.Proudct;
using KASHOP.DAL.DTOS.Response.catgores;
using KASHOP.DAL.DTOS.Response.Proudct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.serveic.Proudct
{
    public interface IProudctServeic
    {
        Task<ProductResponse> CreateProduct(ProductRequest request);
        Task<List<ProductResponse>> Getall_proudcts_forAdmin();
        Task<List<ProudctsuserResponse>> Getall_proudcts_forUser(string lang = "en");
         Task<ProductUserDetails> GetAllProductsDetailsForUser(int id, string lang = "en");
    }
}
