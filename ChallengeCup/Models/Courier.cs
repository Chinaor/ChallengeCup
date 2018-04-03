using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeCup.Models
{
    public class Courier:IUser
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public string Birthday { get; set; }

        [Required]
        public string Sex { get; set; }

        //注册码，用于登录
        public string Code { get; set; }

    }
}
