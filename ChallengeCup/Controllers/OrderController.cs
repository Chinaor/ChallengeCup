using ChallengeCup.Models;
using ChallengeCup.Services;
using ChallengeCup.Util;
using ChallengeCup.Vo;
using ChallengeCup.Vo.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ChallengeCup.Controllers
{
    [Produces("application/json")]
    public class OrderController : Controller
    {
        private readonly OrderService service;
        public OrderController(OrderService service)
        {
            this.service = service;
        }

        public Result Index() => ResultUtil.Success(service.GetAll());

        [Authorize]
        public Result GetOrderByDoctorId() => ResultUtil.Success(service.GetByDoctorId(HttpContext));

        [Authorize]
        public Result GetOrderByUserId() => ResultUtil.Success(service.GetByDoctorId(HttpContext));

        [Authorize]
        public Result AcceptOrder(string id)
        {
            Order order=service.GetById(id);

            if (order == null)
                return ResultUtil.NotFound();

            if (!order.DoctorId.Equals(UserUtil.GetCurrentUserParam(HttpContext, "id")))
                return ResultUtil.UnAuthorazition();

            service.UpdateStatus(order, 2);

            return ResultUtil.Success();
        }

        [Authorize]
        [HttpPost]
        public Result DoPrescription(string id,string Prescription)
        {
            Order order = service.GetById(id);

            if (order == null)
                return ResultUtil.NotFound();

            if (!order.DoctorId.Equals(UserUtil.GetCurrentUserParam(HttpContext, "id")))
                return ResultUtil.UnAuthorazition();

            service.UpdatePrescription(order, Prescription);

            return ResultUtil.Success();
        }

        //user do this
        [Authorize]
        public Result CompleteOrder(string id)
        {
            Order order = service.GetById(id);

            if (order == null)
                return ResultUtil.NotFound();

            if (!order.UserId.Equals(UserUtil.GetCurrentUserParam(HttpContext, "id")))
                return ResultUtil.UnAuthorazition();

            service.UpdateStatus(order, 3);

            return ResultUtil.Success();
        }

        [HttpPost]
        [Authorize]
        public Result PostOrder(Order order)
        {
            service.AddOrder(order,HttpContext);
            return ResultUtil.Success();
        }

    }
}
