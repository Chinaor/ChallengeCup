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

        public static Result Fail(string message)
        {
            return new Result(StatusCode.FAIL, message, null);
        }

        public static Result Fail()
        {
            return new Result(StatusCode.FAIL, "系统出错", null);
        }
    }
}
