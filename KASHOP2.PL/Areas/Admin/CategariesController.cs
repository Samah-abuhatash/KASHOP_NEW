using KASHOP.BLL.serveic;
using KASHOP.DAL.DTOS.Request;
using KASHOP2.PL.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System.Security.Claims;

namespace KASHOP2.PL.Areas.Admin
{
    [Route("api/admin/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class CategariesController : ControllerBase
    {
        //private readonly ICategoryService _category;
        private readonly ICategoryService _categoryserves;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public CategariesController(ICategoryService categoryserves, IStringLocalizer<SharedResource> localizer)
        {
            
            _categoryserves = categoryserves;
            _localizer = localizer;
        }


        [HttpGet("")]
        public async Task<IActionResult> index([FromQuery] string lang = "en")
        {
            var response = await _categoryserves.Getall_categres_forAdmin();
            return Ok(new
            {
                message = _localizer["Success"].Value,
                response

            });
        }
        [HttpPost("")]
        public  async Task<IActionResult> create(CategoryRequest request)

        {
            
            var response =  await _categoryserves.createl_categres(request);
            return Ok(new
            {
                message = _localizer["Success"].Value


            });
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, [FromBody] CategoryRequest request)
        {
            var result = await _categoryserves.UpdateCategoryAsync(id, request);

            if (!result.Success)
            {
                if (result.messages.Contains("Not Found"))
                {
                    return NotFound(result);
                }
                return BadRequest(result);
            }

            return Ok(result);
        }
        [HttpPatch("toggle-status/{id}")]
        public async Task<IActionResult> ToggleStatus(int id)
        {
            var result = await _categoryserves.ToggleStatus(id);

            if (!result.Success)
            {
                if (result.messages.Contains("Not Found"))
                {
                    return NotFound(result);
                }
                return BadRequest(result);
            }

            return Ok(result);
        }
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteCategory([FromRoute] int id)
        {
            var result = await _categoryserves.DeleteCategoryAsync(id);

            if (!result.Success)
            {
                if (result.messages.Contains("Not Found"))
                {
                    return NotFound(result);
                }
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
