using ImagePixalate.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace ImagePixalate.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
        
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewImg(IFormFile postFile)
        {
      

            if (postFile.Length > 0)
            {
                
                string fileName = "NewFile.jpg";
                string fileNameWitPath = "wwwroot/" + fileName;
                using (Stream fileStream = new FileStream(fileNameWitPath, FileMode.Create))
                {
                    await postFile.CopyToAsync(fileStream);
                }
            }



            return RedirectToAction(nameof(New));
            
        }

        public IActionResult New()
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
