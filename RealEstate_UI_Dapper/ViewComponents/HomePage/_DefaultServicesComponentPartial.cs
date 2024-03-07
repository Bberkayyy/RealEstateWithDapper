using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI_Dapper.ViewComponents.HomePage;

public class _DefaultServicesComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
