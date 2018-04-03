using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChallengeCup.Services;
using ChallengeCup.Models;
using ChallengeCup.Vo.Utilities;

namespace ChallengeCup.Controllers
{
    public class CourierController : Controller
    {
        private readonly CourierService service;

        public CourierController(CourierService service)
        {
            this.service = service;

        }

        // GET: Couriers
        public async Task<JsonResult> Index()
        {
            List<Courier> couriers = await service.GetAll();
            return Json(ResultUtil.Success(couriers));
        }

        // GET: Couriers/Details/5
        public async Task<JsonResult> Details(string id)
        {
            if (id == null)
            {
                return Json(ResultUtil.NotFound());
            }

            var courier = await service.GetByIdAsync(id);
            if (courier == null)
            {
                return Json(ResultUtil.NotFound());
            }

            return Json(ResultUtil.Success(courier));
        }

        // POST: Couriers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create(/*[Bind("Name,Sex,Description,Type,Code,PhoneNumber,Birthday")]*/ Courier courier)
        {

            var result = service.Add(courier);
            if (result.Equals("fail"))
            {
                return Json(ResultUtil.InvalidParam());
            }
            else
            {
                return Json(ResultUtil.Success(result));
            }

        }

        //POST: Couriers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Edit(string id, [Bind("UserName,Sex,PhoneNumber,Birthday")] Courier courier)
        {
            courier.Id = id;
            service.Update(courier);

            return Json(ResultUtil.Success());
        }

        // GET: Couriers/Delete/5
        public JsonResult Delete(string id)
        {
            if (id == null)
            {
                return Json(ResultUtil.NotFound());
            }

            var result = service.DeleteById(id);

            if (result.Equals("fail"))
            {
                return Json(ResultUtil.NotFound());
            }
            else
            {
                return Json(ResultUtil.Success());
            }
        }

        [HttpPost]
        public JsonResult Login(Courier courier)
        {
            if (string.IsNullOrWhiteSpace(courier.Code) || string.IsNullOrWhiteSpace(courier.UserName) || string.IsNullOrWhiteSpace(courier.PhoneNumber))
            {
                return Json(ResultUtil.LoginFail("提交的用户信息不完整"));
            }

            var result = service.Login(courier);

            if (result.Equals("fail"))
            {
                return Json(ResultUtil.LoginFail("快递员信息不正确"));
            }
            return Json(ResultUtil.Success(result));
        }
    }
}