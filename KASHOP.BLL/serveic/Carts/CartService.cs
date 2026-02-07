using KASHOP.DAL.DTOS.Request.carts;
using KASHOP.DAL.DTOS.Response.Carts;
using KASHOP.DAL.DTOS.Response.classbase;
using KASHOP.DAL.Moadels.carts;
using KASHOP.DAL.Repostriy.carts;
using KASHOP.DAL.Repostriy.Proudcts;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.BLL.serveic.Carts
{
    public class CartService : ICartService
    {
        private readonly IProudctsRepsotry _proudctsRepsotry;
        private readonly ICartRepository _cartRepository;

        public CartService(IProudctsRepsotry proudctsRepsotry,ICartRepository cartRepository)
        {
            _proudctsRepsotry = proudctsRepsotry;
            _cartRepository = cartRepository;
        }
        public  async Task<BaseResponse> AddToCartAsync(string userID, AddToCartRequest request)
        {
            var product = await _proudctsRepsotry.FindByIdAsync(request.ProductId);

            if (product is null)
            {
                return new BaseResponse
                {
                    Success = false,
                    messages = "Product not found"
                };
            }
            if (product.Quantity < request.Count)
            {
                return new BaseResponse
                {
                    Success = false,
                    messages = "Not enough stock"
                };
            }

            var cart = request.Adapt<Cart>();
            cart.UserId = userID;

            await _cartRepository.createAsync(cart);

            return new BaseResponse
            {
                Success = true,
                messages = "Product added successfully"
            };
        }

        public async Task<CartSummaryResponse> GetUserCartAsync(string userId, string lang = "en")
        {
            var cartItems = await _cartRepository.GetUserCartAsync(userId);
            //var response = cartItems.Adapt<CartResponse>();

            var items = cartItems.Select(c => new CartResponse
            {
                ProductId = c.ProductId,
                ProductName = c.Product.Translations.FirstOrDefault(t => t.Language == lang)?.Name ,
                Count = c.Count,
                Price = c.Product.Price,
               
            }).ToList();

            return new CartSummaryResponse
            {
                Items = items,
              
            };
        }
    }
}
