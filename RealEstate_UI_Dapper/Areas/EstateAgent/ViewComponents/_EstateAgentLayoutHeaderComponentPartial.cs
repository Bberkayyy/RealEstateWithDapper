﻿using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI_Dapper.Areas.EstateAgent.ViewComponents;

public class _EstateAgentLayoutHeaderComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
