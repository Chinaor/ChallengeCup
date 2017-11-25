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
    public class TestController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;

        private readonly SignInManager<ApplicationUser> signInManager;

        private readonly ILogger<TestController> logger;
        public TestController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<TestController> logger)
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

        public async Task<JsonResult> Login(ApplicationUser user)
        {
           var result = await signInManager.PasswordSignInAsync(user, user.PasswordHash, false, false);
            if (result.Succeeded)
            {
                logger.LogDebug("登陆的用户为：{}", user.UserName);
                return Json(ResultUtilities.Success());
            }
            else
            {
                logger.LogDebug("用户 {} 登陆失败", user.UserName);
                return Json(ResultUtilities.LoginFaile());
            }
        }

        public async Task<JsonResult> Logout()
        {
            await signInManager.SignOutAsync();
            logger.LogDebug("用户登出");

        }

        public async Task<JsonResult> Register(ApplicationUser user)
        {

        }
    }
}
