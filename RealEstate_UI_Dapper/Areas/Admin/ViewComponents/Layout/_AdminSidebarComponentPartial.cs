using Microsoft.AspNetCore.Mvc;

namespace RealEstate_UI_Dapper.Areas.Admin.ViewComponents.Layout;

public class _AdminSidebarComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
