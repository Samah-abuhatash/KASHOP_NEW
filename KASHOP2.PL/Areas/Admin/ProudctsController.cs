using KASHOP.BLL.serveic.Proudct;
using KASHOP.DAL.DTOS.Request.Proudct;
using KASHOP2.PL.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace KASHOP2.PL.Areas.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProudctsController : ControllerBase
    {
        private readonly IProudctServeic _proudctServeic;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public ProudctsController(IProudctServeic proudctServeic, IStringLocalizer<SharedResource> localizer)
        {
            _proudctServeic = proudctServeic;
            _localizer = localizer;
        }
        [HttpPost("")]
        public async Task<IActionResult> Create([FromForm] ProductRequest request)
        {
            var response = await _proudctServeic.CreateProduct(request);
            return Ok(new { message = _localizer["Success"].Value, response });
        }
        //get
        [HttpGet("")]
        public async Task<IActionResult> index([FromQuery] string lang = "en")
        {
            var response = await _proudctServeic.Getall_proudcts_forAdmin();
            return Ok(new
            {
                message = _localizer["Success"].Value,
                response

            });
        }

    }
}
