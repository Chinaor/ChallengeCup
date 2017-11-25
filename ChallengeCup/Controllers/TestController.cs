using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ChallengeCup.Models;
using Microsoft.Extensions.Logging;
using ChallengeCup.Vo;
using ChallengeCup.Vo.Utilities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChallengeCup.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly SignInManager<ApplicationUser> signInManager;

        private readonly ILogger<AccountController> logger;
        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Login(User user)
        {
            var result = await signInManager.PasswordSignInAsync(user.Username, user.Password, false, false);
            if (result.Succeeded)
            {
                logger.LogDebug("登陆的用户为：{}", user.Username);
                return Json(ResultUtilities.Success());
            }
            else
            {
                logger.LogDebug("用户 {},{} 登陆失败", user.Username,user.Password);
                return Json(result);
            }
        }

        [HttpGet]
        public async Task<JsonResult> Logout()
        {
            await signInManager.SignOutAsync();
            logger.LogDebug("用户登出");
            return Json(ResultUtilities.Success());
        }

        [HttpPost]
        public async Task<JsonResult> Register(User user)
        {
            logger.LogInformation(user.ToString());
            var applicationUser = new ApplicationUser();
            applicationUser.UserName = user.Username;
            var result = await userManager.CreateAsync(applicationUser, user.Password);
            return Json(result);
        }
    }
}
