using KASHOP.BLL.serveic;
using KASHOP.DAL.DATA;
using KASHOP.DAL.DTOS.Request;
using KASHOP.DAL.DTOS.Response;
using KASHOP.DAL.Moadels;
using KASHOP.DAL.Repostriy;
using KASHOP2.PL.Resources;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace KASHOP2.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoresController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        // private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public CategoresController(ICategoryService categoryService, IStringLocalizer<SharedResource> localizer)
        {
            _categoryService = categoryService;
            //   _context = context;
            _localizer = localizer;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
           var response = _categoryService.Getall_categres();
          //  var response = categories.Adapt<List<Responsecategory>>();

            // ترجع رسالة "Success" مترجمة
            return Ok(new
            {
                message = _localizer["Success"].Value,
                response

            });
           
        }

        [HttpPost("")]
        public IActionResult Create(CategoryRequest request)
        {
            var response= _categoryService.createl_categres(request);

            //   _context.Add(categories);
            // _context.SaveChanges();

            return Ok(new { message = _localizer["Success"].Value });
        }
    }
}
