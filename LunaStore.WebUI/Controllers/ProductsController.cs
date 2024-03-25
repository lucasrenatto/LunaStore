using LunaStore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LunaStore.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productAppService)
        {
            _productService = productAppService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }
    }
}
