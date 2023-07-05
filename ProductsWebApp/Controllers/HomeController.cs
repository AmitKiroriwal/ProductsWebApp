using Microsoft.AspNetCore.Mvc;
using ProductsWebApp.Models;
using System.Diagnostics;

namespace ProductsWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductRepo productRepo;
        private readonly IWebHostEnvironment env;
        public HomeController(IProductRepo productRepo, ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            this.productRepo = productRepo;
            _logger = logger;
            this.env = env;
        }

        
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AddProduct(ProductViewModel products)
        {
            if (ModelState.IsValid)
            {
                string uniqeFileName = null;
                string uniqeFile = null;
                string status = null;

                if (products.PhotoPath != null)
                {
                    string upload = Path.Combine(env.WebRootPath, "images");
                    uniqeFileName = Guid.NewGuid().ToString() + "-" + products.PhotoPath.FileName;
                    string photopath = Path.Combine(upload, uniqeFileName);
                    products.PhotoPath.CopyTo(new FileStream(photopath, FileMode.Create));
                }
                if (products.PdfPath != null)
                {
                    string upload = Path.Combine(env.WebRootPath, "File");
                    uniqeFile = Guid.NewGuid().ToString() + "-" + products.PdfPath.FileName;
                    string pdfpath = Path.Combine(upload, uniqeFile);
                    products.PdfPath.CopyTo(new FileStream(pdfpath, FileMode.Create));
                }
                if (products.Status == "true")
                {
                    status = "Active";
                }
                else
                {
                    status = "InActive";
                }
                Products p = new Products()
                {
                    Category = products.Category,
                    SubCategory = products.SubCategory,
                    ProductName = products.ProductName,
                    PhotoPath = uniqeFileName,
                    ShortDescription = products.ShortDescription,
                    FullDescription = products.FullDescription,
                    Features = products.Features,
                    PdfPath = uniqeFile,
                    Status = status

                };
                var data = await productRepo.AddProduct(p);

            }
            return View(products);
        }
        public async Task<JsonResult> GetAllProducts()
        {
            var data = productRepo.GetProducts();

            return Json(data);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}