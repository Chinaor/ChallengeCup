using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeCup.Models
{
    public class Order
    {
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

    }
}
