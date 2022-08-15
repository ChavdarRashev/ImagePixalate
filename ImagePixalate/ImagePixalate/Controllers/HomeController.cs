using ImagePixalate.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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
        public IActionResult NewImg(string coordinates)
        {
            var list = JsonSerializer.Deserialize<List<Coordinates>>(coordinates);

            using (Image img = Image.FromFile("wwwroot/500.jpg"))
            using (Graphics g = Graphics.FromImage(img))


            using (SolidBrush br = new SolidBrush(Color.Black))
            {
               // g.SmoothingMode = SmoothingMode.AntiAlias;

                foreach (Coordinates coor in list)
                {
                    g.FillRectangle(br, coor.topX, coor.topY, coor.width, coor.heigh);
                }
             

                img.Save("wwwroot/YourNewFile.png");
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
