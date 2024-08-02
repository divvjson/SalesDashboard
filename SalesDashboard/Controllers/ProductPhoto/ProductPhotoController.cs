using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesDashboard.Entities;

namespace SalesDashboard.Controllers.ProductPhoto
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPhotoController : ControllerBase
    {
        private readonly AdventureWorksContext _context;

        public ProductPhotoController(AdventureWorksContext context)
        {
            _context = context;
        }

        [HttpGet("{productPhotoId}")]
        public async Task<IActionResult> Get(int productPhotoId)
        {
            var productPhoto = await _context.ProductPhotos.FirstOrDefaultAsync(pp => pp.ProductPhotoId == productPhotoId);

            if (productPhoto?.LargePhoto is null)
            {
                return NotFound();
            }

            return File(productPhoto.LargePhoto, "image/jpeg");
        }
    }
}
