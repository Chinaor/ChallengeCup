using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChallengeCup.Services;
using ChallengeCup.Vo;
using Microsoft.AspNetCore.Authorization;
using ChallengeCup.Models;
using ChallengeCup.Vo.Utilities;

namespace ChallengeCup.Controllers
{
    [Produces("application/json")]
    public class ScoreController : Controller
    {
        private readonly ScoreService scoreService;

        private readonly OrderService orderService;

        public ScoreController(ScoreService scoreService,
            OrderService orderService)
        {
            this.orderService = orderService;
            this.scoreService = scoreService;
        }

        [Authorize(Roles = "user")]
        public Result Do(string orderId,[Bind("Mark,Evaluate")]Score score)
        {
            var order=orderService.GetOrderWithScore(orderId);

            if (order.Score!=null)
            {
                return ResultUtil.System_Error("已经评价过");
            }

            scoreService.Add(score);
            orderService.UpdateScore(orderId,score);

            return ResultUtil.Success();
        }
    }
}