using System;
using System.ComponentModel.DataAnnotations;

namespace ChallengeCup.Models
{
    public class MedicineOrder
    {
        public MedicineOrder()
        {

        }

        public MedicineOrder(User user, Medicine medicine, int state)
        {
            this.User = user;
            this.Medicine = medicine;
            this.State = state;
            this.Date = new DateTime();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public Medicine Medicine { get; set; }

        //当前订单的状态，1为未接单，2为接单，3为订单完成
        [Required]
        public int State { get; set; }

        public Courier Courier { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }
    }
}
