using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeCup.Models
{
    public class Doctor:IUser
    {
        public string Id { get; set; }

        //姓名
        public string Name { get; set; }

        //性别
        public int Sex { get; set; }

        //介绍
        public string Description { get; set; }

        //医生种类
        public string Type { get; set; }

        //注册码，用于登录
        public string Code { get; set; }

        //电话号码
        public string PhoneNumber { get; set; }

        //出生年月
        public DateTime Birthday { get; set; }

      
    }
}
