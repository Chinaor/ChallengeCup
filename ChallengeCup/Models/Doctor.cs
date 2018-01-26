using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeCup.Models
{
    public class Doctor:IUser
    {

        //快速生成属性，prop 两下tab
                    
        //性别
        [Required]
        public string Sex { get; set; }

        //介绍
        [Required]
        public string Description { get; set; }

        //医生种类
        [Required]
        public string Type { get; set; }

        //注册码，用于登录
        public string Code { get; set; }

        //电话号码
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        //出生年月
        [DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; }

      
    }
}
