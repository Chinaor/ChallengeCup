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
using Microsoft.AspNetCore.Authorization;
using ChallengeCup.Data;
using ChallengeCup.Util;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChallengeCup.Controllers
{
    public class AccountController : Controller
    {

        private readonly ILogger<AccountController> logger;

        private readonly AppDbContext context;

        public AccountController(IAuthorizationService authorizationService,
            AppDbContext context,
            ILogger<AccountController> logger)
        {
            this.logger = logger;
            this.context = context;

        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 在这里实现登陆和jwt的签发
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Login(User user)
        {
            var hasher = new PasswordHasher<User>();
            var userInDb = context.Users.Single(x => x.Username == user.Username);

            logger.LogDebug("用户 {}  正在登陆",user.Username);

            if (userInDb == null) {
                logger.LogDebug("用户 {}  不存在", user.Username);
                return Json(ResultUtilities.LoginFaile("用户名不存在"));
            }
            var result = hasher.VerifyHashedPassword(user, userInDb.Password, user.Password);
            if (result == PasswordVerificationResult.Success)
            {
                logger.LogDebug("用户 {}  登陆成功", user.Username);
                //登陆成功
                return Json(ResultUtilities.Success(TokenUtil.getToken(user)));
            }
            else
            {
                logger.LogDebug("用户 {}  用户名或密码错误", user.Username);
                //登陆失败
                return Json(ResultUtilities.LoginFaile("用户名或密码错误"));
            }
        }


        public async Task<JsonResult> Register(User user)
        {
            var userInDb=context.Users.SingleOrDefault(x => x.Username == user.Username);
            if (userInDb != null)
            {
                return Json(ResultUtilities.Fail("用户已经存在"));
            }

            var hasher = new PasswordHasher<User>();
            user.Password = hasher.HashPassword(user, user.Password);

            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();

            logger.LogDebug("用户：{} 注册成功", user.Username);
            return Json(ResultUtilities.Success(TokenUtil.getToken(user)));
        }

        [Authorize]
        [HttpPost]
        public JsonResult Test1()
        {
            logger.LogDebug("测试授权");
            return Json("hello");
        }

        [AllowAnonymous]
        [HttpPost]
        public JsonResult Test2()
        {
            //authorizationService.AuthorizeAsync()
            logger.LogDebug("测试授权2");
            return Json("hello");
        }
    }
}
