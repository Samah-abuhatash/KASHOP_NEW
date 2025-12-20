using KASHOP.BLL.serveic;
using KASHOP.DAL.DTOS.Request;
using KASHOP2.PL.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace KASHOP2.PL.Areas.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize]
    public class CategariesController : ControllerBase
    {
        private readonly ICategoryService _category;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public CategariesController(ICategoryService category, IStringLocalizer<SharedResource> localizer)
        {
            _category = category;
            _localizer = localizer;
        }

        [HttpPost("")]
        public IActionResult create(CategoryRequest request)
        {
            var response = _category.createl_categres(request);
            return Ok(new
            {
                message = _localizer["Success"].Value


            });
        }
    }
}
