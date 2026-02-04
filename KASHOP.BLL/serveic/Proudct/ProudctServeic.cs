using KASHOP.BLL.serveic.Fileserveis;
using KASHOP.DAL.DTOS.Request.Proudct;
using KASHOP.DAL.DTOS.Response.catgores;
using KASHOP.DAL.DTOS.Response.Proudct;
using KASHOP.DAL.Moadels.Proudct;
using KASHOP.DAL.Repostriy.Catgores;
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
            if (request.SubImages != null)
            {
                product.subImages = new List<ProductImage>();

                foreach (var file in request.SubImages)
                {
                    var imagePath = await _ifileservice.UploadAsync(file);
                    product.subImages.Add(new ProductImage
                    {
                        ImageName = imagePath
                    });
                }
            }

            await _proudctServeic.AddAsync(product);

            return product.Adapt<ProductResponse>();
        }
        public async Task<List<ProductResponse>> Getall_proudcts_forAdmin()
        {
            var products = await _proudctServeic.GetAllAsync();

            var response = products.Adapt<List<ProductResponse>>();
            return response;
        }
    }
}
