using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI_Dapper.Areas.EstateAgent.Controllers;

[Area("EstateAgent")]
[Route("EstateAgent/[controller]")]
public class DashboardController : Controller
{
    [Route("Index")]
    public IActionResult Index()
    {
        return View();
    }
}
