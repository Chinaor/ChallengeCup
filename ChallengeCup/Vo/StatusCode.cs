using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeCup.Vo
{
    public enum StatusCode
    {
        SUCCES=200,
        NOT_FOUND=404,
        SYSTEM_ERROR=500,
        LOGIN_FAIL=4001,
        INVALID_PARAM=4002,
    }
}
