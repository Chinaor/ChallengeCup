using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeCup.Authorization
{

    /// <summary>
    /// 可以在这个类中实现一些用户权限的过滤等操作
    /// 通过注入 private readonly IAuthorizationService authorizationService;
    /// 调用其AuthorizeAsync方法完成授权等操作。
    /// 可以自定义授权等，
    /// http://www.cnblogs.com/RainingNight/p/dynamic-authorization-in-asp-net-core.html
    /// </summary>
    public class UserAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement>
    {

        ILogger<UserAuthorizationHandler> logger;

        public UserAuthorizationHandler(ILogger<UserAuthorizationHandler> logger)
        {
            this.logger = logger;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement)
        {
            logger.LogDebug("在Authorization handler中");
            return Task.FromResult(0);
        }
    }
}
