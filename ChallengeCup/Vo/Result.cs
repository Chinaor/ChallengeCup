using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeCup.Vo
{
    public class Result
    {
        public Result(StatusCode StatusCode, string Message,object Data)
        {
            this.StatusCode = StatusCode;
            this.Message = Message;
            this.Data = Data;
        }

        public Result()
        {

        }

        public StatusCode StatusCode { get; set; }

        public string Message { get; set; }
        
        public object Data { get; set; }
    }
}
