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
using TextAnalyticsMVCCoreBootstrap.MostFrequentChars;
using TextAnalyticsMVCCoreBootstrap.Services;

namespace TextAnalyticsMVCCoreBootstrap.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IWebHostEnvironment _appEnvironment;
        //private readonly Analytic _analytic;
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment appEnvironment)//, Analytic analytic)
        {
            _logger = logger;
            _appEnvironment = appEnvironment;
          //  _analytic = analytic;
        }

        public IActionResult Index()
        {           
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddFile(IList<IFormFile> files)
        {
            var uploadedFile1 = files[0];
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

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> MostFrequentChar([FromBody]string fileName)
        {
            // путь к папке Files
            var file = System.IO.Path.Combine(_appEnvironment.WebRootPath, "Files", fileName);

            if (!System.IO.File.Exists(file))
            {
                // Create a file to write to.
                //string createText = "File not found";
                return NotFound();
            }
            string text = System.IO.File.ReadAllText(file);
            if (text==null)
            {
                // Create a file to write to.
                //string createText = "File not found";
                return NotFound();
            }

            var algoritm = new MostFrequentChar<AnswerModel<int>>();
            Analytic<AnswerModel<int>> _analytic = new Analytic<AnswerModel<int>>();
                       
            var result = _analytic.Execute(algoritm, text);

            return Ok(result);
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
