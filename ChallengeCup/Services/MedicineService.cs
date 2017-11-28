using ChallengeCup.Data;
using ChallengeCup.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeCup.Services
{
    public class MedicineService
    {
        private readonly ChallengeCupDbContext context;

        private readonly ILogger<MedicineService> logger;

        public MedicineService(ChallengeCupDbContext context,
            ILogger<MedicineService> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        public void Add(Medicine medicine)
        {
            context.Add(medicine);
            context.SaveChanges();
        }

        public List<Medicine> GetAll()
        {
            return context.Medicine.ToList();
        }

        public Medicine GetById(string id) => context.Medicine.SingleOrDefault(i => i.Id.Equals(id));

        public void Delete(string id)
        {
            var medicine=context.Medicine.SingleOrDefault(i => i.Id.Equals(id));

            if (medicine==null)
            {
                return;
            }

            context.Remove(medicine);
            context.SaveChanges();
        }
    }
}
