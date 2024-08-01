using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace RealEstate_UI_Dapper.ViewComponents.Layout;

public class _NavbarViewComponentPartial : ViewComponent
{
    private readonly IHttpContextAccessor _contextAccessor;

    public _NavbarViewComponentPartial(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public IViewComponentResult Invoke()
    {
        var userRole = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
        ViewBag.userRole = userRole;
        return View();
    }
}
