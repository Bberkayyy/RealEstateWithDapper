﻿using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI_Dapper.ViewComponents.HomePage;

public class _DefaultFeatureComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
