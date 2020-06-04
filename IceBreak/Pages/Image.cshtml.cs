using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IceBreak.Pages
{
    public class ImageModel : PageModel
    {
        [BindProperty]
        public IFormFile FormFile { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            // do something with username and password

            var filePath = Path.GetTempPath();
            var file = Path.Combine(filePath, FormFile.FileName);

            using (var stream = System.IO.File.Create(file))
            {
                FormFile.CopyToAsync(stream);
            }

            // or you can redirect to another page
            TempData["Success"] = 1;
            TempData["Message"] = FormFile.FileName;
            TempData["Url"] = Path.Combine(filePath,FormFile.FileName);
            return Redirect("/ImageResult");
        }
    }

   
}