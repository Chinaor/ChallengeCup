using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeCup.Vo.Utilities
{
    public class ResultUtilities
    {
        public static Result Success()
        {
            return new Result(StatusCode.SUCCES,"success",null);
        }

        public static Result Success(object Data)
        {
            return new Result(StatusCode.SUCCES, "success", Data);
        }

        public static Result LoginFaile()
        {
            return new Result(StatusCode.LOGIN_FAILE, "login faile", null);
        }
    }
}
