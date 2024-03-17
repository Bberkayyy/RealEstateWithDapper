using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI_Dapper.Areas.EstateAgent.Controllers;

[Area("EstateAgent")]
public class LayoutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
