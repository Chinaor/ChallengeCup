using System;
using System.ComponentModel.DataAnnotations;

namespace ChallengeCup.Models
{
    public class MedicineOrder
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string MedicineId { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}
