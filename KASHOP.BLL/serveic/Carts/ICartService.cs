using KASHOP.DAL.DTOS.Request.carts;
using KASHOP.DAL.DTOS.Response.classbase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.serveic.Carts
{
    public  interface ICartService
    {
        Task<BaseResponse> AddToCartAsync(string userID, AddToCartRequest request);

    }
}
