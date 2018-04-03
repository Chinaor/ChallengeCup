using ChallengeCup.Data;
using ChallengeCup.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeCup.Services
{
    public class MedicineOrderService
    {
        private readonly ILogger<MedicineOrderService> logger;
        private readonly ChallengeCupDbContext context;

        public MedicineOrderService(ILogger<MedicineOrderService> logger,
                     ChallengeCupDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public List<MedicineOrder> GetAll()
        {
           return context.MedicineOrder.ToList();
        }

        public List<MedicineOrder> GetByUser(string id)
        {
            return context.MedicineOrder.Where(i => i.User.Id.Equals(id)).ToList();
        }

        public List<MedicineOrder> GetByCourier(string id)
        {
            List<MedicineOrder> result = null;
            try
            { 
                result = context.MedicineOrder.Where(i => i.Courier.Id.Equals(id)).ToList();
            }
            catch (Exception e)
            {
                logger.LogDebug("该快递员未接受任何订单");
            }
            return result;
        }

        public List<MedicineOrder> GetUnAccepted()
        {
            return context.MedicineOrder.Where(i => i.State.Equals(1)).ToList();
        }

        public Object Add(String medicineId, String userId)
        {
            Medicine medicine = context.Medicine.Single(i => i.Id.Equals(medicineId));
            User user = context.User.Single(i => i.Id.Equals(userId));
            MedicineOrder order = new MedicineOrder(user, medicine, 1);
            context.Add<MedicineOrder>(order);
            context.SaveChanges();
            return order;
        }

        public void UpdateState(string medicineOrderId, int state)
        {
            var orderInDb = context.MedicineOrder.Single(i => i.Id.Equals(medicineOrderId));
            orderInDb.State = state;
            context.MedicineOrder.Update(orderInDb);
            context.SaveChanges();
        }

    }
}
