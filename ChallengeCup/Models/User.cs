using System;
using System.ComponentModel.DataAnnotations;

namespace ChallengeCup.Models
{
    public class User:IUser
    {
        //密码
        [Required(ErrorMessage = "密码不可为空")]
        [DataType(DataType.Password)]
        public string  Password { get; set; }

        //性别
        [Required]
        public string Sex { set; get; }

        //出生日期
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Birthday { get; set; }

        //住址
        [Required]
        [DataType(DataType.Text)]
        public string Address { get; set; }

        //是否单独生活
        [Required]
        [Range(0,1)]
        public int Alone { get; set; }

        //紧急联系电话
        [StringLength(11)]
        [RegularExpression("^ ((13[0 - 9]) | (14[5 | 7]) | (15([0 - 3] |[5 - 9])) | (18[0, 5 - 9]))\\d{8}$",ErrorMessage ="手机号格式不正确")]
        [DataType(DataType.PhoneNumber)]
        public string FamilyPhoneNumber { get; set; }

        
    }
}
