using System;

namespace ChallengeCup.Models
{
    public class MedicineOrder
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public string MedicineId { get; set; }

        public DateTime Date { get; set; }
    }
}
