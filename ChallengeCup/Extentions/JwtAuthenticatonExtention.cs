
namespace ChallengeCup.Authorization
{
    using ChallengeCup.Vo.Utilities;
    using Microsoft.AspNetCore.Authentication.JwtBearer;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.IdentityModel.Tokens;
    using Newtonsoft.Json;
    using System;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public static class JwtAuthenticatonExtention
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.Events = new JwtBearerEvents()
                    {
                        OnTokenValidated = context =>
                        {
                            //在这里获取验证之后的token
                            return Task.CompletedTask;
                        },

                        //认证失败的时候调用
                        OnAuthenticationFailed = c =>
                        {
                            c.NoResult();
                            c.Response.StatusCode = 401;

                            return c.Response.WriteAsync(JsonConvert.SerializeObject(ResultUtil.LoginFaile("认证失败")));
                        }
                    };

                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        //这里填写生成token的时候放在claim中的username和role的key
                        NameClaimType = ClaimTypes.NameIdentifier,
                        RoleClaimType = ClaimTypes.Role,
                       
                        ValidIssuer = "lmy",
                        ValidAudience = "api",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Consts.Consts.Secret)),

                        /***********************************TokenValidationParameters的参数默认值***********************************/
                        RequireSignedTokens = true,
                        SaveSigninToken = false,
                        ValidateActor = false,
                        //将下面两个参数设置为false，可以不验证Issuer和Audience，但是不建议这样做。
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        //是否要求Token的Claims中必须包含Expires
                        RequireExpirationTime = true,
                        //允许的服务器时间偏移量
                        ClockSkew = TimeSpan.FromSeconds(300),
                        //是否验证Token有效期，使用当前时间与Token的Claims中的NotBefore和Expires对比
                        ValidateLifetime = true
                    };

                    //不使用https
                    o.RequireHttpsMetadata = false;
                });

            return services;
        }
    }
}
