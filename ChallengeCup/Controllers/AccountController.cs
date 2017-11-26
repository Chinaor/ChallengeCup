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

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChallengeCup.Controllers
{
    public class AccountController : Controller
    {

        private readonly ILogger<AccountController> logger;
        public AccountController(IAuthorizationService authorizationService,
            ILogger<AccountController> logger)
        {
            this.logger = logger;

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
        public async Task<JsonResult> Login(User user)
        {
            return Json("init");
        }

      

        [Authorize(Roles = "user")]
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
