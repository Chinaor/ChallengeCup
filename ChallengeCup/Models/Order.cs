using System;
using System.ComponentModel.DataAnnotations;

namespace ChallengeCup.Models
{
    public class Order
    {
        [Key]
        public string Id { get; set; }

        //订单地址
        [DataType(DataType.Text)]
        [Required]
        public string Address { get; set; }

        //发起订单的用户
        [Required]
        public string UserId { get; set; }

        //要求使用的医生
        [Required]
        public string DoctorId { get; set; }

        //订单发起日期
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        //订单描述，病情描述
        [DataType(DataType.Text)]
        [Required]
        public string Description { get; set; }

        //当前订单的状态，1为未接单，2为接单，3为订单完成
        [Range(1,3)]
        [Required]
        public int Status { get; set; }

        //医生开的处方，
        [DataType(DataType.Text)]
        public string Prescription { get; set; }

        public Score Score { get; set; }

    }
}
