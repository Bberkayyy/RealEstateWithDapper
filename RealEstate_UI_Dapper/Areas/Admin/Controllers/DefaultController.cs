using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI_Dapper.Areas.Admin.Controllers;

[Area("Admin")]
public class DefaultController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
