using KASHOP.DAL.DATA;
using KASHOP.DAL.DTOS.Request;
using KASHOP.DAL.DTOS.Response;
using KASHOP.DAL.Moadels;
using KASHOP2.PL.Resources;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace KASHOP2.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public CategoresController(ApplicationDbContext context, IStringLocalizer<SharedResource> localizer)
        {
            _context = context;
            _localizer = localizer;
        }

        [HttpGet("")]
        public IActionResult Index()
        {//.Include(c => c.translations).ToList();
            var categories = _context.Catgores.Include(c => c.translations).ToList();
            var response = categories.Adapt<List<Responsecategory>>();

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
            var categories = request.Adapt<Categores>();
            _context.Add(categories);
            _context.SaveChanges();

            return Ok(new { message = _localizer["Success"].Value });
        }
    }
}
