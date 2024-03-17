using System.Security.Claims;

namespace RealEstate_UI_Dapper.Services;

public class LoginService : ILoginService
{
    private readonly IHttpContextAccessor _contextAccessor;

    public LoginService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public string Id => _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
}
