using ChallengeCup.Models;
using ChallengeCup.Services;
using ChallengeCup.Util;
using ChallengeCup.Vo.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChallengeCup.Controllers
{
    public class UserController : Controller
    {

        private readonly ILogger<UserController> logger;

        private readonly UserService userService;

        public UserController(IAuthorizationService authorizationService,
                UserService userService,
            ILogger<UserController> logger)
        {
            this.logger = logger;
            this.userService = userService;

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
            string result=userService.Login(user);

            if (result.Equals("success"))
            {
                user = userService.GetUserByUsername(user.UserName);
                logger.LogDebug("当前用户{}", user.Id);
                return Json(ResultUtil.Success(TokenUtil<User>.GetToken(user,"user")));
            }
            else
            {
                return Json(ResultUtil.LoginFaile(result));
            }
        }


        public async Task<JsonResult> Register(User user)
        {
            string result=await userService.AddUserAsync(user);
            if (result.Equals("success"))
            {
                 return Json(ResultUtil.Success(TokenUtil<User>.GetToken(user,"user")));
            }
            else
            {
                return Json(ResultUtil.System_Error(result));
            }

        }

        [Authorize]
        [HttpPost]
        public JsonResult Test1()
        {
            logger.LogDebug("测试授权");
            return Json("hello");
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public JsonResult Test2()
        {
            logger.LogDebug("测试授权2");
            return Json("hello");
        }
    }
}
