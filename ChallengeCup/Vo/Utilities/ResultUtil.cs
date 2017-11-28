namespace ChallengeCup.Vo.Utilities
{
    public class ResultUtil
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
            return new Result(StatusCode.LOGIN_FAIL, "login faile", null);
        }

        public static Result LoginFaile(string message)
        {
            return new Result(StatusCode.LOGIN_FAIL, message, null);
        }

        public static Result System_Error(string message)
        {
            return new Result(StatusCode.SYSTEM_ERROR, message, null);
        }

        public static Result System_Error()
        {
            return new Result(StatusCode.SYSTEM_ERROR, "系统出错", null);
        }

        public static Result NotFound()
        {
            return new Result(StatusCode.NOT_FOUND, "资源未找到", null);
        }

        public static Result InvalidParam()
        {
            return new Result(StatusCode.INVALID_PARAM, "参数错误", null);
        }
    }
}
