using ChallengeCup.Data;
using ChallengeCup.Models;
using ChallengeCup.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeCup.Services
{
   
    public class CourierService
    {
        private readonly ILogger<CourierService> logger;
        private readonly ChallengeCupDbContext context;

        public CourierService(ILogger<CourierService> logger,
                             ChallengeCupDbContext context )
        {
            this.logger = logger;
            this.context = context;
        }

        public object Add(Courier courier)
        {
            if (string.IsNullOrWhiteSpace(courier.UserName) || string.IsNullOrWhiteSpace(courier.PhoneNumber))
            {
                return "fail";
            }

            string code = Guid.NewGuid().ToString();
            courier.Code = code;
            context.Add(courier);
            context.SaveChanges();
            return courier;
        }

        public async Task<Courier> GetByIdAsync(string id) => await context.Courier.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<List<Courier>> GetAll() => await context.Courier.ToListAsync();

        public string DeleteById(string id)
        {
            var courier = context.Courier.SingleOrDefault(x => x.Id.Equals(id));
            if (courier == null)
            {
                return "fail";
            }

            context.Courier.Remove(courier);
            context.SaveChanges();
            return "success";
        }

        public void Update(Courier courier)
        {
            context.Update(courier);
            context.SaveChanges();
        }

        public object Login(Courier courier)
        {
            var courierInDb = context.Courier.SingleOrDefault(x => x.UserName.Equals(courier.UserName) && x.PhoneNumber.Equals(courier.PhoneNumber) && x.Code.Equals(courier.Code));

            logger.LogDebug("快递员username{}", courier.UserName);
            logger.LogDebug("快递员phone{}", courier.PhoneNumber);
            logger.LogDebug("快递员code{}", courier.Code);

            if (courierInDb == null)
            {
                return "fail";
            }
            return TokenUtil<Courier>.GetToken(courierInDb, "courier");
        }
    }
}
