using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChallengeCup.Models;
using ChallengeCup.Data;
using ChallengeCup.Services;
using ChallengeCup.Vo.Utilities;

namespace ChallengeCup.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ChallengeCupDbContext _context;

        private readonly DoctorService service;

        public DoctorController(ChallengeCupDbContext context,
            DoctorService service)
        {
            this.service = service;
            _context = context;
        }

        // GET: Doctors
        public async Task<JsonResult> Index()
        {
            List<Doctor> doctors = await service.GetAll();
            return Json(ResultUtil.Success(doctors));
        }

        // GET: Doctors/Details/5
        public async Task<JsonResult> Details(string id)
        {
            if (id == null)
            {
                return Json(ResultUtil.NotFound());
            }

            var doctor = await service.GetByIdAsync(id);
            if (doctor == null)
            {
                return Json(ResultUtil.NotFound());
            }

            return Json(ResultUtil.Success(doctor));
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Create(/*[Bind("Name,Sex,Description,Type,Code,PhoneNumber,Birthday")]*/ Doctor doctor)
        {

            var result = service.Add(doctor);
            if (result.Equals("fail"))
            {
                return Json(ResultUtil.InvalidParam());
            }
            else
            {
                return Json(ResultUtil.Success(result));
            }

        }

        //POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public JsonResult Edit(string id, [Bind("Id,Name,Sex,Description,Type,Code,PhoneNumber,Birthday")] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return Json(ResultUtil.NotFound());
            }
            service.update(doctor);

            return Json(ResultUtil.Success());
        }

        // GET: Doctors/Delete/5
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
        public JsonResult Login(Doctor doctor)
        {
            if (string.IsNullOrWhiteSpace(doctor.Code)||string.IsNullOrWhiteSpace(doctor.Name)||string.IsNullOrWhiteSpace(doctor.PhoneNumber))
            {
                return Json(ResultUtil.LoginFaile("提交的用户信息不完整"));
            }

            var result=service.Login(doctor);

            if (result.Equals("fail"))
            {
                return Json(ResultUtil.LoginFaile("医生信息不正确"));
            }
            return Json(ResultUtil.Success(result));
        }

    }
}
