using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeCup.Models
{
    public class User
    {
        
        public string Id { get; set; }
        //用户名
        public string  Username { get; set; }

        //密码
        public string  Password { get; set; }

        //性别
        public int Sex { set; get; }

        //出生日期
        public DateTime Birthday { get; set; }

        //住址
        public string Address { get; set; }

        //是否单独生活
        public int Alone { get; set; }

        //紧急联系电话
        public string FamilyPhoneNumber { get; set; }

        
    }
}
