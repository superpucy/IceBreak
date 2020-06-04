﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace IceBreak.Pages
{
    public class GuestYNModel : PageModel
    {
        [BindProperty]
        public int RoomId { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            TempData["RoomId"] = RoomId;
            return Redirect("/PlayYN");
        }
    }
}