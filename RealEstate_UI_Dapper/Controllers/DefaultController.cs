﻿using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI_Dapper.Controllers;

public class DefaultController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
