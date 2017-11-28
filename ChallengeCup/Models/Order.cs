using System;
using System.ComponentModel.DataAnnotations;

namespace ChallengeCup.Models
{
    public class Order
    {
        [Key]
        public string Id { get; set; }

        //订单地址
        public string Address { get; set; }

        //发起订单的用户
        public string UserId { get; set; }

        //要求使用的医生
        public string DoctorId { get; set; }

        //订单发起日期
        public DateTime Date { get; set; }

        //订单描述，病情描述
        public string Description { get; set; }

        //当前订单的状态，1为未接单，2为接单，3为订单完成
        public int Status { get; set; }

        //医生开的处方，
        public string Prescription { get; set; }

        public Score Score { get; set; }

    }
}
