using KASHOP.BLL.serveic;
using KASHOP.DAL.DTOS.Request;
using KASHOP2.PL.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace KASHOP2.PL.Areas.user
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoresController : ControllerBase
    {
        private readonly ICategoryService _category;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public CategoresController(ICategoryService category ,IStringLocalizer<SharedResource> localizer)
        {
            _category = category;
            _localizer = localizer;
        }
        
        [HttpGet("")]
        public async Task< IActionResult> index() {
            var response =  await _category.Getall_categres();
            return Ok(new
            {
                message = _localizer["Success"].Value,
                response

            });
        }
       
    }
}
