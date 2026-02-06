using KASHOP.BLL.serveic.catgores;
using KASHOP.BLL.serveic.Proudct;
using KASHOP2.PL.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace KASHOP2.PL.Areas.user
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProudctsController : ControllerBase
    {
        private readonly IProudctServeic _ProudctServeic;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public ProudctsController(IProudctServeic ProudctServeic, IStringLocalizer<SharedResource> localizer)
        {
            _ProudctServeic = ProudctServeic;
            _localizer = localizer;
        }

        [HttpGet("")]
        public async Task<IActionResult> index([FromQuery] string lang = "en")
        {
            var response = await _ProudctServeic.Getall_proudcts_forUser(lang);
            return Ok(new
            {
                message = _localizer["Success"].Value,
                response

            });
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Index([FromRoute] int id, [FromQuery] string lang = "en")
        {
            var response = await _ProudctServeic.GetAllProductsDetailsForUser(id, lang);
            return Ok(new { message = _localizer["Success"].Value, response });
        }
    }
}
