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
    public class DoctorService
    {
        private readonly ILogger<DoctorService> logger;
        private readonly ChallengeCupDbContext context;

        public DoctorService(ILogger<DoctorService> logger,
            ChallengeCupDbContext context)
        {
            this.logger = logger;
            this.context = context;
        }

        public object Add(Doctor doctor)
        {
            if (string.IsNullOrWhiteSpace(doctor.UserName) || string.IsNullOrWhiteSpace(doctor.PhoneNumber))
            {
                return "fail";
            }

            string code = Guid.NewGuid().ToString();
            doctor.Code = code;
            context.Add(doctor);
            context.SaveChanges();
            return doctor;
        }

        public async Task<Doctor> GetByIdAsync(string id) => await context.Doctor.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<List<Doctor>> GetAll() => await context.Doctor.ToListAsync();

        public string DeleteById(string id)
        {
            var doctor = context.Doctor.SingleOrDefault(x => x.Id.Equals(id));
            if (doctor == null)
            {
                return "fail";
            }

            context.Doctor.Remove(doctor);
            context.SaveChanges();
            return "success";
        }

        public void Update(Doctor doctor)
        {
            context.Update(doctor);
            context.SaveChanges();
        }

        public object Login(Doctor doctor)
        {
            var doctorInDb = context.Doctor.SingleOrDefault(x => x.UserName.Equals(doctor.UserName) && x.PhoneNumber.Equals(doctor.PhoneNumber) && x.Code.Equals(doctor.Code));

            if (doctorInDb==null)
            {
                return "fail";
            }
            return TokenUtil<Doctor>.GetToken(doctorInDb, "doctor");
        }
    }
}
