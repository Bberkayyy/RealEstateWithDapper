using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI_Dapper.ViewComponents.Layout;

public class _HeaderViewComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
