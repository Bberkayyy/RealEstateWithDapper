using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RealEstate_UI_Dapper.Models;
using RealEstate_UI_Dapper.Models.CategoryViewModels;

namespace RealEstate_UI_Dapper.ViewComponents.HomePage;

public class _DefaultFeatureComponentPartial : ViewComponent
{
    public IViewComponentResult Invoke() { return View(); }
}
