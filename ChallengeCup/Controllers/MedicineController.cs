using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ChallengeCup.Services;
using ChallengeCup.Vo.Utilities;
using ChallengeCup.Vo;
using ChallengeCup.Models;

namespace ChallengeCup.Controllers
{
    [Produces("application/json")]
    public class MedicineController : Controller
    {
        private readonly MedicineService medicineService;

        public MedicineController(MedicineService medicineService)
        {
            this.medicineService = medicineService;
        }
        // GET: Medicine
        public Result Index() => ResultUtil.Success(medicineService.GetAll());


        public Result Details(string id) => ResultUtil.Success(medicineService.GetById(id));
        
        [HttpPost]
        public Result Create(Medicine medicine)
        {
            medicineService.Add(medicine);
            return ResultUtil.Success();
        }
    
 
        // GET: Medicine/Delete/5
        public Result Delete(string id)
        {
            medicineService.Delete(id);
            return ResultUtil.Success();
        }

      
    }
}