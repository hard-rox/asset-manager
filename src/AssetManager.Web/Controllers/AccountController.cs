using AssetManager.Core.Entities;
using AssetManager.Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AssetManager.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILogger _logger;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<AccountController> logger
                )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var user = new User() { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if(result.Succeeded)
                {
                    _logger.LogInformation("User registred.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    //return RedirectToLocal(returnUrl);
                }
                //AddErrors(result);
            }
            return View(model);
        }
    }
}