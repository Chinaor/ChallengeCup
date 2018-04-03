using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChallengeCup.Vo;
using ChallengeCup.Vo.Utilities;
using Microsoft.Extensions.Logging;
using ChallengeCup.Services;
using ChallengeCup.Util;
using Microsoft.AspNetCore.Authorization;

namespace ChallengeCup.Controllers
{
    [Produces("application/json")]
    public class MedicineOrderController : Controller
    {

        private readonly ILogger<MedicineOrderController> logger;
        private readonly MedicineOrderService service;

        public MedicineOrderController(ILogger<MedicineOrderController> logegr,
                                    MedicineOrderService service)
        {
            this.logger = logegr;
            this.service = service;
        }

        public Result GetAll()=> ResultUtil.Success(service.GetAll());

        [Authorize(Roles = "user")]
        public Result GetByUser() => ResultUtil.Success(service.GetByUser(UserUtil.GetCurrentUserParam(HttpContext, "id")));

        [Authorize(Roles = "coutier")]
        public Result GetByCourier() => ResultUtil.Success(service.GetByCourier(UserUtil.GetCurrentUserParam(HttpContext, "id")));

        public Result GetUnAccepted() => ResultUtil.Success(service.GetUnAccepted());

        [Authorize(Roles = "user")]
        public Result Post(string medicineId)
        {
            service.Add(medicineId, UserUtil.GetCurrentUserParam(HttpContext, "id"));
            return ResultUtil.Success();
        }

        [Authorize(Roles = "courier")]
        public Result Accept(string medicineOrderId)
        {
            service.UpdateState(medicineOrderId, 2);
            return ResultUtil.Success();
        }

        [Authorize(Roles = "user, courier")]
        public Result completeOrder(String medicineOrderId)
        {
            service.UpdateState(medicineOrderId, 3);
            return  ResultUtil.Success();
        }
    }
}
