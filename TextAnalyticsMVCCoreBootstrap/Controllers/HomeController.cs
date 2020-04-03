using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TextAnalyticsMVCCoreBootstrap.Models;

namespace TextAnalyticsMVCCoreBootstrap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IWebHostEnvironment _appEnvironment;
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment appEnvironment)
        {
            _logger = logger;
            _appEnvironment = appEnvironment;
        }

        //public IActionResult Index()
        //{           
        //    return View();
        //}
        public IActionResult Index(string fileName)
        {
            ViewBag.FileName = fileName;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddFile(IFormFile uploadedFile1)
        {
            if (uploadedFile1 != null)
            {
                // путь к папке Files
                string path = "/Files/" + uploadedFile1.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile1.CopyToAsync(fileStream);
                }
                FileModel file = new FileModel { Name = uploadedFile1.FileName, Path = path };
                
            }
            
            return RedirectToAction("Index", new { @fileName = uploadedFile1.FileName });
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
