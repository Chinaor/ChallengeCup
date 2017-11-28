using System;

namespace ChallengeCup.Models
{
    public class User:IUser
    {

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
