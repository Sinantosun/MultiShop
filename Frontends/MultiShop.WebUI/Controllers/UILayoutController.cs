﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;

namespace MultiShop.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
       

        public IActionResult Index()
        {
          
            return View();

        }
    }
}
