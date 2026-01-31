using KASHOP.DAL.DTOS.Request.Proudct;
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
    }
}
