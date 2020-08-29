
using System.Threading.Tasks;
using FACode.MessageBus;
using FACode.WebAPI.Core.Auth;
using FACode.WebAPI.Core.Controller;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace FACode.Identidade.API.Controllers
{
  [Route("api/manage")]
  public class ManageUsersController : MainController
  {
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly AppSettings _appSettings;
    private readonly IMessageBus _bus;

    public ManageUsersController(SignInManager<IdentityUser> signInManager,
        UserManager<IdentityUser> userManager,
        IOptions<AppSettings> appSettings,
        IMessageBus bus)
    {
      _signInManager = signInManager;
      _userManager = userManager;
      _appSettings = appSettings.Value;
      _bus = bus;
    }

    [HttpGet("users")]
    public ActionResult ListarUsuarios()
    {
      var users = _userManager.Users;
      return CustomResponse(users);
    }
  }
}