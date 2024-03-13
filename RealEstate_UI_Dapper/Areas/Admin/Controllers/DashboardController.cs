using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI_Dapper.Areas.Admin.Controllers;

[Area("Admin")]
[Route("Admin/[controller]")]
public class DashboardController : Controller
{
    [Route("Index")]
    public IActionResult Index()
    {
        return View();
    }
}
