using KASHOP.BLL.serveic.Fileserveis;
using KASHOP.DAL.DTOS.Request.Proudct;
using KASHOP.DAL.DTOS.Response.Proudct;
using KASHOP.DAL.Moadels.Proudct;
using KASHOP.DAL.Repostriy.Proudcts;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.serveic.Proudct
{
    public class ProudctServeic : IProudctServeic
    {
        private readonly IProudctsRepsotry _proudctServeic;
        private readonly Ifileservice _ifileservice;

        public ProudctServeic(IProudctsRepsotry proudctServeic,Ifileservice ifileservice)
        {
            _proudctServeic = proudctServeic;
            _ifileservice = ifileservice;
        }
        public  async Task<ProductResponse> CreateProduct(ProductRequest request)
        {
            var product = request.Adapt<Product>();

            if (request.MainImage != null)
            {
                var imagePath = await _ifileservice.UploadAsync(request.MainImage);
                product.MainImage = imagePath;
            }

            await _proudctServeic.AddAsync(product);

            return product.Adapt<ProductResponse>();
        }
    }
}
